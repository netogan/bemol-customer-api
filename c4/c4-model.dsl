workspace {

    model {
        // N�vel 1: Diagrama de Contexto
        user = person "Cliente" {
            description "Cliente que utiliza o sistema para gerenciar o cadastro."
        }

        // N�vel 1: Sistema
        api = softwareSystem "API de Cadastro de Cliente" {
            description "API respons�vel pelo CRUD de clientes."

            // N�vel 2: Diagrama de Cont�iner
            // Defini��o dos principais cont�ineres, incluindo a API e o banco de dados PostgreSQL.
            apiController = container "CustomerController" {
                description "Controller respons�vel pelo CRUD de clientes."
                technology ".NET 8 Web API"
            }

            service = container "CustomerService" {
                description "Service que cont�m a l�gica de neg�cios relacionada ao cliente."
                technology ".NET 8 Service"
            }

            repository = container "CustomerRepository" {
                description "Repository respons�vel pela intera��o com o banco de dados PostgreSQL."
                technology ".NET 8 Repository"
            }

            database = container "PostgreSQL Database" {
                description "Banco de dados para armazenar informa��es de clientes."
                technology "PostgreSQL"
            }
        }

        // Defini��o das rela��es entre os elementos no diagrama de cont�iner.
        user -> apiController "Usa"
        apiController -> service "Chama"
        service -> repository "Usa"
        repository -> database "Interage com"
    }

    views {
        // N�vel 1: Diagrama de Contexto
        systemContext api {
            include *
            autolayout lr
            title "Diagrama de Contexto - API de Cadastro de Cliente"
        }

        // N�vel 2: Diagrama de Cont�iner
        container api {
            include *
            autolayout lr
            title "Diagrama de Cont�iner - API de Cadastro de Cliente"
        }

        // N�vel 3: Diagrama de Componentes
        component service {
            include apiController
            include service
            include repository
            autolayout lr
            title "Diagrama de Componentes - API de Cadastro de Cliente"
        }

        // Aplicando o tema padr�o.
        theme default
    }
}
