namespace HandChef.Shared.Commands
{
    public class GenericResult : ICommandResult
    {
        public GenericResult()
        {
        }

        public GenericResult(object dados)
        {
            Dados = dados;
        }

        public object Dados { get; set; }
    }
}
