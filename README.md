Projeto: MoviesWorld Cup

IDE: Visual Studio 2017
Linguagem: HTML/ Javascript / C# / CSS
Framework: Bootstrap 4
.Net FrameWork 4.6.2

 ==== Descrição ====

Projeto copa filmes para simular um campeonato de filmes, após seleção dos filmes pelo usuário serão executadas em cada partida uma série de regras para validar os ganhadores de cada fase até a fase final.
Regras: Vence o filme com maior nota. Em caso de empate o desempate será feito por ordem alfabética.

Desenvolvido utilizando os conceitos de MVC, utilizando ASP.Net, orientação a objetos e microservicos (consumir api externa para simular dados).

 ==== Como executar a aplicação =====

1) Executando o Micro Serviço:

Para executar a aplicação (Site) é necessário executar antes o microservico (MoviesWorldCupService), responsável por conectar na api externa e retornar os dados utilizados.

2) Executando a aplicação (Site):
O proximo passo é alterar no arquivo Web.config da aplicação (MoviesWorldCupSite), caso necessário! A tag dentro de <appSettings>, chave (key) "UrlMicroServico" para a url em que o microservico está em execução localmente.

3) Feito isso basta executar a aplicação.

 ==== Como executar os testes unitários ====

1) Executando o Micro Serviço:

2) Executando a aplicação (Site):

Ernando Rocha Silva.
Contato:
Cel: +55 11 96131-8087
E-mail: ernando.rs@hotmail.com/ernando.rsilva@gmail.com




