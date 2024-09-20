workspace {

    model {
        // Nível 1: Diagrama de Contexto
        user = person "Cliente" {
            description "Cliente que utiliza o sistema para gerenciar o cadastro."
        }

        // Nível 1: Sistema
        api = softwareSystem "API de Cadastro de Cliente" {
            description "API responsável pelo CRUD de clientes."

            // Nível 2: Diagrama de Contêiner
            // Definição dos principais contêineres, incluindo a API e o banco de dados PostgreSQL.
            apiController = container "CustomerController" {
                description "Controller responsável pelo CRUD de clientes."
                technology ".NET 8 Web API"
            }

            service = container "CustomerService" {
                description "Service que contém a lógica de negócios relacionada ao cliente."
                technology ".NET 8 Service"
            }

            repository = container "CustomerRepository" {
                description "Repository responsável pela interação com o banco de dados PostgreSQL."
                technology ".NET 8 Repository"
            }

            database = container "PostgreSQL Database" {
                description "Banco de dados para armazenar informações de clientes."
                technology "PostgreSQL"
            }
        }

        // Definição das relações entre os elementos no diagrama de contêiner.
        user -> apiController "Usa"
        apiController -> service "Chama"
        service -> repository "Usa"
        repository -> database "Interage com"
    }

    views {
        // Nível 1: Diagrama de Contexto
        systemContext api {
            include *
            autolayout lr
            title "Diagrama de Contexto - API de Cadastro de Cliente"
        }

        // Nível 2: Diagrama de Contêiner
        container api {
            include *
            autolayout lr
            title "Diagrama de Contêiner - API de Cadastro de Cliente"
        }

        // Nível 3: Diagrama de Componentes
        component service {
            include apiController
            include service
            include repository
            autolayout lr
            title "Diagrama de Componentes - API de Cadastro de Cliente"
        }

        // Aplicando o tema padrão.
        theme default
    }
}
