using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using TesteWebMotors.Dominio.Models;
using TesteWebMotors.Dominio.Repositories;
using TesteWebMotors.Dominio.Services;

namespace TesteWebMotors.Dominio
{
    internal class Program
    {
        public static IConfiguration configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();

            AnuncioWebRepository anuncioWebRepository = new AnuncioWebRepository(configuration);
            AnuncioWebService anuncioWebService = new AnuncioWebService(configuration);

            //------------------------------------------------------- Adicionar as Informações no Banco 
            //AnuncioWeb anuncioWeb = new AnuncioWeb();
            //anuncioWeb.Marca = "Marca19";
            //anuncioWeb.Modelo = "Modelo19";
            //anuncioWeb.Versao = "Versao19";
            //anuncioWeb.Ano = 1929;
            //anuncioWeb.Quilometragem = 1239293;
            //anuncioWeb.Observacao = "Aqui 99499 entra as observações";
            //anuncioWebService.AdicionarAnuncios(anuncioWeb);
            ////------------------------------------------------------------------------------------------  

            //------------------------------------------------------ Demonstrar todos os anuncios da web
            //List<AnuncioWeb> listaDeAnuncios = anuncioWebService.ConsultarAnuncios();
            //foreach (AnuncioWeb anuncio in listaDeAnuncios)
            //{
            //    Console.WriteLine(anuncio.ID);
            //    Console.WriteLine(anuncio.Marca);
            //    Console.WriteLine(anuncio.Modelo);
            //    Console.WriteLine(anuncio.Versao);
            //    Console.WriteLine(anuncio.Ano);
            //    Console.WriteLine(anuncio.Quilometragem);
            //    Console.WriteLine(anuncio.Observacao);
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}
            //------------------------------------------------------------------------------------------  

            //--------------------------------------------------------- excluir todos os anuncios da web
            //Console.Write("Digite o ID do Anuncio: ");
            //int idAnuncioWeb = int.Parse(Console.ReadLine());
            //anuncioWebService.ExcluirAnuncios(idAnuncioWeb);
            //Console.WriteLine("--------------------------------------------------------- Alteração ");
            //Console.Write("Digite o ID do Anuncio: ");
            //int idAnuncioWeb = int.Parse(Console.ReadLine());
            //AnuncioWeb anuncioWeb = new AnuncioWeb();
            //AnuncioWeb anuncioWeb1 = new AnuncioWeb();
            //anuncioWeb = anuncioWebService.ConsultarUnicoAnuncios(idAnuncioWeb);
            //Console.WriteLine(anuncioWeb.Marca);
            //Console.WriteLine(anuncioWeb.Modelo);
            //Console.WriteLine(anuncioWeb.Versao);
            //Console.WriteLine(anuncioWeb.Ano);
            //Console.WriteLine(anuncioWeb.Quilometragem);
            //Console.WriteLine(anuncioWeb.Observacao);
            //Console.WriteLine("--------------------------------------------------------------------");
            ////anuncioWeb.Marca = "Citroen";
            ////anuncioWeb.Modelo = "Fiat";
            ////anuncioWeb.Versao = "1,6";
            ////anuncioWeb.Ano = 1994;
            ////anuncioWeb.Quilometragem = 1239293;
            //anuncioWeb.Observacao = "Carro da Familia, agora vai ficar de vez na familia";
            //Console.WriteLine(anuncioWeb.Marca);
            //Console.WriteLine(anuncioWeb.Modelo);
            //Console.WriteLine(anuncioWeb.Versao);
            //Console.WriteLine(anuncioWeb.Ano);
            //Console.WriteLine(anuncioWeb.Quilometragem);
            //Console.WriteLine(anuncioWeb.Observacao);
            //Console.WriteLine("--------------------------------------------------------------------");
            //anuncioWebService.AlterarAnuncio(anuncioWeb);
            //Console.WriteLine("---------------------------------------------------- Alterado ------");
            //anuncioWeb1 = anuncioWebService.ConsultarUnicoAnuncios(idAnuncioWeb);
            //Console.WriteLine(anuncioWeb1.Marca);
            //Console.WriteLine(anuncioWeb1.Modelo);
            //Console.WriteLine(anuncioWeb1.Versao);
            //Console.WriteLine(anuncioWeb1.Ano);
            //Console.WriteLine(anuncioWeb1.Quilometragem);
            //Console.WriteLine(anuncioWeb1.Observacao);
            //Console.WriteLine("--------------------------------------------------------------------");
            //Console.ReadLine();
        }

    }
}
