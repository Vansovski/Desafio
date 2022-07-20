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
A API foi desenvolvida com ASP.NET FrameWork na versão 6.0.300, Entity FrameWork Core versão 6.0.5.
</p>
<p>
Para representação do Banco de Dados foi utilizado SQLite.
</p>
<p>
A documentação da API está disponivel também pelo Swagger.
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

<img alt="Readme" title="Swagger1" src="/Image/camadas.png">

# EndPoints da API
A URL base vai depender das disponibilidade de porta em tempo de execução, por exemplo baseURL = https://localhost:7026.

<p>Para Cotista temos:</p>
<ul>
  <li>Metodo GET ------> baseURL/api/Cotista</li>
  <p>***Obtém todos os cotista da Ação, a resposta será um array de Cotistas no formato JSON.
  </p>
  <li>Metodo GET ------> baseURL/api/Cotista/id</li>
  <p>***Obtém Cotista pelo ID, a resposta será um Json de Cotista.</p>
  <br>
  <li>Metodo POST base/api/Cotista</li>
  <p>***Adiciona um novo Cotista, forneça um body de requisição no formato JSON com os campos nome, dataNascimento, cpf.
  </p>
  <p>
    A resposta será um Cotista no formato JSON com a Id e quantidade de Cotas, junto com os campos fornecidos.
  </p>
 </ul>
 <p>
<br>
<p>Para Operações temos:</p>
<ul>
  <li>Metodo GET ------> baseURL/api/Operacao</li>
  <p>***Obtém todos as Opeaçẽos da Ação, a resposta será um array de Operações no formato JSON.
  </p>
  <li>Metodo GET ------> baseURL/api/Operacao/id</li>
  <p>***Obtém Operação pelo ID, a resposta será um JSON de Operação.</p>
  <br>
  <li>Metodo POST base/api/Operacao</li>
  <p>***Adiciona um nova Operacao, forneça um body de requisição no formato JSON com os campos idCotistas, tipoOperacao, cotas.
  </p>
  <p>
    A resposta será uma Operação no formato JSON, com o Valor da Cota, data da Operação e Id da mesma.
  </p>
 </ul>
<br>

# Instruções
Para inicializar a aplicação faça o git clone na pasta desejada. Depois navegue pelo terminal de comando para pasta Desafio/src e entre com o comando: 
'''
<p>$ dotnet run -p Invest.API/</p>
'''
<p>Dessa forma a aplicação estará em funcionamento e será disponibilizado as portas de escuta para as requisições<p>



# Swagger
<p>
<div>
  <img alt="Readme" title="Swagger1" src="/Image/ResumoSwagger.png">
  <img alt="Readme" title="Swagger2" src="/Image/MetodosSwagger.png">
  <img alt="Readme" title="Swagger2" src="/Image/CotistasSwagger.png">
</div>
</p>

# Postman
<p>
<div>
  <img alt="Readme" title="Postman1" src="/Image/GETCotistasPostman.png">
  <img alt="Readme" title="Postman2" src="/Image/POSTOperacaoPostaman.png">
</div>
</p>
