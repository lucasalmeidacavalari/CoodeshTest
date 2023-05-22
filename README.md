# CoodeshTest

Uma aplicação de exportação e parsing de arquivo e visualização de seus respectivos dados.

## Tecnologias

- C#: O projeto CoodeshTest foi desenvolvido utilizando a linguagem de programação C# para a implementação da lógica de negócio e a criação de APIs com o framework ASP.NET Core.

- ASP.NET Core: O projeto utiliza o framework ASP.NET Core para o desenvolvimento de APIs RESTful. O ASP.NET Core oferece recursos poderosos para criar serviços web escaláveis e de alto desempenho.

- Entity Framework Core: O projeto faz uso do Entity Framework Core como um ORM (Object-Relational Mapper) para a camada de acesso a dados. O Entity Framework Core simplifica a interação com o banco de dados, permitindo que você modele os dados usando classes e consultas LINQ.

- React: O projeto CoodeshTest.React.Ui utiliza a biblioteca React.js para construir a interface de usuário interativa. O React é uma biblioteca JavaScript popular para criação de interfaces de usuário dinâmicas e reativas.

- HTML e CSS: Para a estruturação e estilização da interface de usuário, o projeto utiliza as linguagens HTML (HyperText Markup Language) e CSS (Cascading Style Sheets).

- SQL Server: O projeto utiliza o banco de dados SQL Server como armazenamento de dados. O SQL Server é um sistema de gerenciamento de banco de dados relacional robusto e amplamente utilizado.

- JavaScript e npm: Para gerenciar as dependências do projeto e automatizar tarefas, como compilação e empacotamento dos recursos front-end, são utilizados o JavaScript (para escrever scripts) e o npm (Node Package Manager) como gerenciador de pacotes.

## Configuração do Projeto CoodeshTest.Api no Visual Studio

1. Abra o Visual Studio.

2. Selecione **Arquivo** no menu superior e clique em **Abrir** > **Projeto/Solução**.

3. Navegue até a pasta onde o projeto CoodeshTest.Api está localizado e selecione o arquivo .sln (arquivo de solução).

4. Aguarde até que o Visual Studio carregue o projeto.

5. No Solution Explorer, clique com o botão direito do mouse no projeto **CoodeshTest.Api** e selecione **Definir como Projeto de Inicialização**.

6. Verifique se o IIS Express está selecionado no menu suspenso de perfil de depuração, localizado na barra de ferramentas superior.

7. Pressione F5 ou clique em **Iniciar Depuração** para executar o projeto CoodeshTest.Api no IIS Express.

8. O projeto CoodeshTest.Api será iniciado e estará pronto para receber solicitações.

## Configuração do Projeto CoodeshTest.React.Ui com o npm

1. Abra o prompt de comando ou terminal.

2. Navegue até a pasta onde o projeto CoodeshTest.React.Ui está localizado.

3. Execute o seguinte comando para instalar as dependências do projeto:
   ```
   npm i
   ```

4. Após a conclusão da instalação das dependências, execute o seguinte comando para iniciar o projeto de interface de usuário React:
   ```
   npm start
   ```

5. O projeto CoodeshTest.React.Ui será compilado e iniciado. O navegador padrão será aberto automaticamente exibindo a interface de usuário React.

## Criação do Banco de

 Dados e Ajuste da String de Conexão

1. Abra o Visual Studio.

2. Certifique-se de que o projeto CoodeshTest.Infra.Data esteja incluído na solução. Se não estiver incluído, siga as etapas mencionadas anteriormente para adicionar o projeto à solução.

3. No Visual Studio, abra o "Package Manager Console" selecionando **Ferramentas** > **Gerenciador de Pacotes NuGet** > **Console do Gerenciador de Pacotes**.

4. No "Package Manager Console", certifique-se de que o projeto padrão seja definido como "CoodeshTest.Infra.Data".

5. Execute o seguinte comando para criar o banco de dados e aplicar as migrações:
   ```
   update-database
   ```

6. Após a conclusão da migração do banco de dados, navegue até a pasta onde o projeto CoodeshTest.Api está localizado.

7. Abra o arquivo "appsettings.json" localizado na raiz do projeto.

8. Procure a seção "ConnectionStrings" no arquivo "appsettings.json".

9. Ajuste a string de conexão para apontar para o banco de dados criado. Substitua as informações necessárias, como o nome do servidor, o nome do banco de dados, o nome de usuário e a senha.

10. Salve as alterações no arquivo "appsettings.json".

11. Reinicie o projeto CoodeshTest.Api para aplicar as alterações na string de conexão.

Parabéns! Você configurou com sucesso o projeto CoodeshTest no Visual Studio, iniciou o projeto de interface de usuário React e criou o banco de dados usando as migrações. Agora você pode começar a trabalhar no projeto CoodeshTest.