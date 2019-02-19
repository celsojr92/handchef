using Dapper;
using HandChef.Domain.Commands.Inputs;
using HandChef.Domain.Repositories;
using HandChef.Shared.Entities;
using OT.Hub.Infra.Contexts;
using System;
using System.Threading.Tasks;

namespace HandChef.Infra.Repositories
{
    public class RecipeRepository : Notifiable, IRecipeRepository
    {
        private readonly AppDataContext _context;

        public RecipeRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(AddRecipeCommand command)
        {
            var rollBack = false;
            long recipeId = 0;

            await _context.Connection.OpenAsync();

            try
            {
                try
                {
                    recipeId = await AddRecipe(command);

                    rollBack = !(await AddRecipeIngredient(command, recipeId));
                }
                catch (Exception ex)
                {
                    this.AddNotification("0", ex.Message);
                    rollBack = true;
                }

                if (rollBack)
                {
                    await DeleteRecipe(recipeId);
                }
            }
            finally
            {
                recipeId = 0;
                _context.Connection.Close();
            }

            return recipeId > 0;
        }

        public async Task<long> AddRecipe(AddRecipeCommand command)
        {
            long recipeId;

            try
            {
                var selector = @"
                    insert into recipe (
                      title,
                      directions)
                    values (
                      @title,
                      @directions)
                    returning recipeId;";

                var parameters = new
                {
                    title = command.Title,
                    directions = command.Directions
                };

                recipeId = await _context.Connection.ExecuteScalarAsync<long>(selector, parameters);
            }
            catch (Exception ex)
            {
                AddNotification("0", ex.Message);
                recipeId = 0;
            }

            return recipeId;
        }

        public async Task<bool> AddRecipeIngredient(AddRecipeCommand command, long recipeId)
        {
            try
            {
                var selector = @"
                    insert into recipeIngredient (
                      amount,
                      unitOfMeasurement,
                      ingredient,
                      recipeId)
                    values (
                      @amount,
                      @unitOfMeasurement,
                      @ingredient,
                      @recipeId)";

                foreach (var item in command.Ingredients)
                {
                    var parameters = new
                    {
                        amount = item.Amount,
                        unitOfMeasurement = item.UnitOfMeasurement,
                        ingredient = item.Ingredient.IngredientId,
                        recipeId = recipeId
                    };

                    await _context.Connection.ExecuteAsync(selector, command);
                }
            }
            catch (Exception ex)
            {
                AddNotification("0", ex.Message);
                return false;
            }

            return true;
        }

        private async Task DeleteRecipe(long recipeId)
        {
            try
            {
                using (var tr = _context.Connection.BeginTransaction())
                {
                    await _context.Connection.ExecuteAsync($"delete from recipe where recipeId = {recipeId}", null, tr);
                    await _context.Connection.ExecuteAsync($"delete from recipeIngredient where recipeId = {recipeId};", null, tr);

                    tr.Commit();
                }
            }
            catch (Exception ex)
            {
                AddNotification("0", ex.Message);
            }
        }
    }
}
