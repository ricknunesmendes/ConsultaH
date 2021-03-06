# ConsultaH

Projeto em ASP.NET MVC 5 seguindo os seguintes requisitos:

### Cadastro de Paciente (CRUD) onde a entidade deve conter as seguintes informações:

* :white_check_mark: Nome - Não pode ter mais que 100 caracteres

* :white_check_mark: CPF - Validar se CPF válido e se já existe CPF cadastrado na base para outro paciente

* :white_check_mark: Data de nascimento 

* :white_check_mark: Sexo

* :white_check_mark: Telefone - Não pode ser um telefone inválido

* :white_check_mark: E-mail - Não pode ser um e-mail inválido

### Cadastro de tipos de exame (CRUD) onde a entidade deve conter as seguintes informações:

* :white_check_mark: Nome do tipo de exame (ex: Hemograma, Raio X e etc) - Não pode ter mais que 100 caracteres

* :white_check_mark: Descrição - Não pode ter mais que 256 caracteres

### Cadastro de Exames (CRUD) onde a entidade deve conter as seguintes informações:

* :white_check_mark: Nome do exame - Não pode ter mais que 100 caracteres

* :white_check_mark: Observações - Não pode ter mais que 1000 caracteres

* :white_check_mark: Id do tipo de exame - Não pode ser nulo

### Marcação de consulta. O sistema deverá ter a opção de cadastrar uma consulta com as seguintes regras:

* :white_check_mark: Seleção de paciente cadastrado (Consultar por nome ou CPF). Caso não tenha cadastro, deverá exibir uma opção para redirecionar para tela de cadastro.

* :white_check_mark: Campo para seleção de tipo de exame que, após selecionado, irá carregar uma combo com os exames cadastrados para o tipo selecionado.

* :white_check_mark: Deverá ter data e hora e não poderá conflitar horários. Exemplo: Se informar um exame para o dia 23/11/2020 às 8:00 e o mesmo já estiver em uso em uma outra consulta o sistema não deverá permitir.

* :white_check_mark: Gerar número de protocolo único para a consulta

### Além dos requisitos

* :white_check_mark: Arquitetura DDD

* :white_check_mark: Injeção de Dependência com Ninject.MVC5

* :white_check_mark: Checagem de horário passado

## Observações:

* :white_check_mark: Utilizar Aspnet MVC 5 e EF (Entity Framework)

* :white_check_mark: Utilizar um local DB ou SQL Server



 ### :warning: Atenção para a execução do projeto
 
 1. No <i>Package Manager Console</i>, digite: 
 
 ```
 Update-Database -ProjectName ConsultaH.Infra
 ```
 
 2. Clique na solution com o botão direito do mouse.
 3. Selecione na opção Clean Solution.
 4. Depois clique novamente com o botão direito do mouse.
 5. Selecione a opção Build.
 
## Screenshots

##### Página Home - Desktop

![Screenshot 1 - Home - Desktop](../main/Screenshots/screenshot-1-home.JPG)

##### Página Home - Mobile

![Screenshot 1 - Home - Mobile](../main/Screenshots/screenshot-1-home-mobile.JPG)

##### Página de Exames - Desktop

![Screenshot 2 - Exames - Desktop](../main/Screenshots/screenshot-2-exames.JPG)

##### Página Consultas - Desktop

![Screenshot 3 - Consultas - Desktop](../main/Screenshots/screenshot-3-consultas.JPG)

##### Página Pacientes - Desktop

![Screenshot 4 - Pacientes - Desktop](../main/Screenshots/screenshot-4-pacientes.JPG)

##### Página Tipo de Exames - Desktop

![Screenshot 5 - Tipo de Exames - Desktop](../main/Screenshots/screenshot-5-tipoExames.JPG)
<br>
### :newspaper: Frase Motivadora

> “O código limpo não é escrito seguindo um conjunto de regras. Você não se torna um artesão de software aprendendo uma lista de heurísticas. Profissionalismo e habilidade vêm de valores que impulsionam as disciplinas.”
<br>
<i>Uncle Bob</i> - Clean Code :blue_book:
