# Especificação de APIs

> A especificação de APIs descreve os principais endpoints da API RESTful do produto
> de software, os métodos HTTP associados a cada endpoint, suas descrições, os formatos
> de respostas, os parâmetros de URL esperados e o mecanismo de autenticação e autorização 
> utilizado.

| Endpoint                             | Método | Descrição                                      | Parâmetros                        | Formato da Resposta | Autenticação e Autorização |
|--------------------------------------|--------|------------------------------------------------|-----------------------------------|---------------------|----------------------------|
| /login       | POST   | Realizar o login do usuario no sistema          |         NULL          | JSON                | JWT Token                  |
| /user/spaces | GET   | Volta todos os espaços que o usuário possui      |         NULL         | JSON                | JWT Token                  |
| /user/spaces | POST    | Criar um novo espaço coworking para alugar     |         id_space              | JSON                | JWT Token                  |
| /user/spaces/{id_space} | PUT    | Atualizar informações de um espaço já cadastrado |  id_space     | JSON                | JWT Token                  |
| /user/reservations | DELETE | Excluir um espaço coworking                 |      NULL           | JSON                | JWT Token                  |
| /user/reservations | GET | Volta todos os espaços que o usuário possui    |      NULL           | JSON                | JWT Token                  |
| /user/spaces/{id_space} | POST | Criar um novo espaço coworking para alugar  |     id_space         | JSON                | JWT Token                  |
| /user/spaces/{id_space} | PUT  | Atualizar informações de um espaço já cadastrado  |   id_space     | JSON                | JWT Token                  |
| /spaces | DELETE | Excluir um espaço coworking                 |          NULL                  | JSON                | JWT Token                  |
| /spaces/reserve | GET | Busca todas              |                   NULL                       | JSON                | JWT Token                  |
| /spaces/reservations/{id_reservation}  | POST | Realizar uma reserva                  |  id_reservation   | JSON                | JWT Token                  |
| /spaces/reservations/{id_reservation} |PUT | Altera uma reserva já existente  |      id_reservation       | JSON                | JWT Token                  |
| /{user} | GET | Buscar dados do usuário                |                   user                 | JSON                | JWT Token                  |
| /{user} | PUT  | Alterar dados do usuário                 |                user               | JSON                | JWT Token                  |
| /user | POST | Realiza o cadastro de um usuário                 |           NULL                | JSON                | JWT Token                  |



[Retorna](../README.md)
