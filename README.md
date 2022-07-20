# Desafio Trinus

<h2 align="center">Projeto de Controle de Cotistas e de Compra e Venda de Cotas</h2>
<br>
<br>
<p>O projeto disponibiliza o serviço de Back-End da ação PORT11</p>
<hr>

<p align="left">
  <a href="#Tecnologias e Versões"> Tecnologias e Versões </a>
  <br>
  <a href="#Arquitetura"> Arquitetura </a>
  <br>
  <a href="#EndPoints da API"> EndPoints da API </a>
  <br>
  <a href="#Instruções"> Instruções </a>
  <br>
  <br>
  <a href="#Swagger"> Swagger </a>
  <br>
  <a href="#Postman"> Postman </a>
  <br>
</p>


# Tecnologias e Versões
<p>
A API foi desenvolvida com ASP.NET frameWork na versão 6.0.300, Entity FrameWork Core versão 6.0.5.
</p>
<p>
Para representação do Banco de Dados foi utilizado SQLite.
</p>
<p>
A documentação da API está disponivel tambpelo Swagger.
</p>


# Arquitetura
<p>A estrutura é composta por dois Controllers, CotistasController e OperacaoController</p>
<p>Utilizando SOLID para o desenvolvimento, optou-se por desacoplar as funcionalidades em 4 camdas:<p>
<ul>
  <li>Operações HTTP --------->Invest.API</li>
  <li>Serviços --------------------->Invest.Application</li>
  <li>Dominio da Aplicação --->Invest.Domain</li>
  <li>Comunicação com BD -->Invest.Persistence</li>
</ul>

# EndPoints da API
A URL base vai depender das disponibilidade de porta em tempo de execução, por exemplo baseURL = https://localhost:7026.

<p>Para Cotista temos:</p>
<ul>
  <li>Metodo GET ------> baseURL/api/Cotista</li>
  ***Obtém todos os cotista da Ação
  <br>
  <li>Metodo GET ------> baseURL/api/Cotista/id</li>
  ***Obtém Cotista pelo ID
  <br>
  <li>Metodo POST base/api/Cotista</li>
  ***Adiciona um novo Cotista
 </ul>
<br>
<p>Para Operações temos:</p>
<ul>
  <li>Metodo GET ------> baseURL/api/Operacao</li>
  ***Obtém todos as Opeaçẽos da Ação
  <br>
  <li>Metodo GET ------> baseURL/api/Operacao/id</li>
  ***Obtém Operação pelo ID
  <br>
  <li>Metodo POST base/api/Operacao</li>
  ***Adiciona um nova Operacao
 </ul>
<br>

# Instruções
Para inicializar a aplicação faça o git clone na pasta desejada. Depois navegue pelo terminal de comando para pasta Desafio/src e entre com o comando: 
<p>$ dotnet run -p Invest.API/</p>
<p>Dessa forma a aplicação estará em funcionamento e será disponibilizado as portas de escuta para as requisições<p>



# Swagger
<p>
<div>
  <img alt="Readme" title="Swagger" src="/Image/ResumoSwagger.png">
  <img alt="Readme" title="Swagger" src="/Image/MetodosSwagger.png">
</div>
</p>

# Postman
