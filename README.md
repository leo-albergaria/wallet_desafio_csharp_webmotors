<img src="https://user-images.githubusercontent.com/63436406/159382782-0e0a5aab-a2b4-4c90-8068-10071f3850ae.png" align="left" height="150px" width="150px">
<h1>  🎲 Desafio em C# para processo seletivo </h1>
<p> Aqui será apresentado um desafio para demonstrar a aquisição do conhecimento oferecido em Curso de C# pela Webmotor no programa Clássicos 50+.</p>
<br />
O teste consiste na criação de um anúncio na Webmotors utilizando uma aplicação WEB em .NET.<br />
A avaliação consiste em como será feita a arquitetura do seu código, funcionamento e qualidade geral da aplicação.<br />

<br />
**Temos 2 pontos de desafio propostos:**<br />
    1. Manipulação de dados no banco de dados<br />
    2. Consumo de API<br />
<br />
Para isso é necessário criar a seguinte estrutura no seu banco de dados local:<br />
<br />
create database teste_webmotors<br />
go;<br />
<br />
create table teste_webmotors..tb_AnuncioWebmotors(<br />
    ID INT identity not null, <br />
    marca varchar (45) not null, <br />
    modelo varchar (45) not null, <br />
    versao varchar (45) not null, <br />
    ano INT not null,<br />
    quilometragem INT not null, <br />
    observacao text not null<br />
)<br />
<br />
O objetivo do teste é chegar em uma tela básica de crud de anúncios, onde seja possível:<br />
    • Incluir<br />
    • Atualizar<br />
    • Consultar<br />
    • Removeranúncios da tabela com consumo das informações de marca, modelo e versão via webservice<br />
<br />

---

<p align="right">
# Hello <img src="https://acegif.com/wp-content/gifs/ola-47.gif" width="29px">
# Um pouco sobre mim #
</p>    
<p align="right">
    <a href="https://web.dio.me/users/leo_albergaria?tab=achievements">
        <img style="border-radius: 50px; height: 50px; width: 90px"
             src="https://user-images.githubusercontent.com/63436406/155859846-da9d78e9-c7c4-47ca-a95c-43fed103bd46.png"/>
    <a href="https://www.linkedin.com/in/adm-leo-albergaria/">
        <img style="border-radius: 50px; height: 50px; width: 90px"
             src="https://user-images.githubusercontent.com/63436406/155859988-26ceade2-4e04-473a-8a26-796b145a4224.png" />
    <a href="https://github.com/leo-albergaria">
        <img style="border-radius: 50px; height: 50px; width: 90px"
             src="https://user-images.githubusercontent.com/63436406/155860021-d9d51434-9fe1-4233-a70a-6b69d5f85792.png" /></a>
</p>
