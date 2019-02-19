#!/bin/bash

# Verifica a existencia de pelo menos um parametro
if [ $# -eq 0 ]
  then
    echo "Nenhuma versao especificada"
	exit 1
fi

# Verifica se existem alterações não commitadas
set -e
echo -n "Checking if there are uncommited changes... "
trap 'echo -e "\033[0;31mFAILED\033[0m"' ERR
git diff-index --quiet HEAD --
trap - ERR
echo -e "\033[0;32mAll set!\033[0m"

BRANCH=$(git rev-parse --abbrev-ref HEAD)
if [[ "$BRANCH" != "dev" ]]; then
  echo 'Somente gerar versão na dev';
  exit 1;
fi

version='v'$1;

# Seta a versão na api
cd HandChef.API/
dotnet setversion $1

# Sobe as alterações para o git
git add .
git commit -m $version
git tag $version
git push origin $version
git push origin dev

