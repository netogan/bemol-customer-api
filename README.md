# Desafio Bemol

Documentação do desafio.

## Documento C4 
Arquivo C4 pode ser acessado [aqui](https://github.com/netogan/bemol-customer-api/blob/main/c4/c4-model.dsl).

## Módulo
- [bemol-customerapi](https://github.com/netogan/bemol-customer-api) - Responsável pelo cadastro de cliente.

## Padrões 
- Separation into logical layers (controller, domain, data, repository, integrations).
- Dependecy injection with .NET.
- DTO use for transference of the data from API and the data base.

## Algumas tecnologias e pacotes
- ``.NET 8``
- ``Swagger``
- ``Entity Framework Core``
- ``RestSharp``
- ``PostgreSQL``

## Criação do cluster
Instruções para criação do cluster kubernetes na estrutura do docker desktop e minikube.

### Prerequisites
- Winget
- Docker Desktop
- Kubectl CLI

### Instalação

Para instalar o Winget (microsoft package manager) acesse o link abaixo. [link](https://learn.microsoft.com/pt-br/windows/package-manager/winget/#install-winget).

Para instalar do Docker Desktop 
```sh
winget install -e --id Docker.DockerDesktop
```
Instalar o Kubectl CLI.
```sh
winget install -e --id Kubernetes.kubectl
```

Deployment do módulo bemol-consumerapi no diretório da solution, include configMap and service.
```sh
kubectl apply -f .\k8s\customer-api.yaml
```