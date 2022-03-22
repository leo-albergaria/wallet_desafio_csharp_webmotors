using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TesteWebMotors.Dominio.Models;

namespace TesteWebMotors.Dominio.Repositories
{
    public class AnuncioWebRepository
    {
        private SqlConnection _sqlConnection;
        private readonly string _tabelaAnuncio = "tb_AnuncioWebmotors";

        public AnuncioWebRepository(IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("MainWay");
            _sqlConnection = new SqlConnection(stringConnection);
        }

        public void AdicionarAnuncioRepository(AnuncioWeb anuncioWeb)
        {
            string comando = $@"INSERT INTO {_tabelaAnuncio} 
                        (marca, modelo, versao, ano, quilometragem, observacao) VALUES 
                        (@marca, @modelo, @versao, @ano, @quilometragem, @observacao)";

            var sqlComando = new SqlCommand(comando, _sqlConnection);

            sqlComando.AdicionarParametrosDeAnuncio(
                anuncioWeb.Marca,
                anuncioWeb.Modelo,
                anuncioWeb.Versao,
                anuncioWeb.Ano,
                anuncioWeb.Quilometragem,
                anuncioWeb.Observacao);


            _sqlConnection.Open();
            sqlComando.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public List<AnuncioWeb> ObterAnuncioRepository()
        {
            string comando = $"SELECT * FROM {_tabelaAnuncio} ORDER BY ID DESC";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            List<AnuncioWeb> anunciosDaWeb = new List<AnuncioWeb>();

            _sqlConnection.Open();

            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                var anuncios = new AnuncioWeb()
                {
                    ID = (int)resultado["ID"],
                    Marca = resultado["marca"].ToString(),
                    Modelo = resultado["modelo"].ToString(),
                    Versao = resultado["versao"].ToString(),
                    Ano = (int)resultado["ano"],
                    Quilometragem = (int)resultado["quilometragem"],
                    Observacao = resultado["observacao"].ToString()
                };

                anunciosDaWeb.Add(anuncios);
            }

            _sqlConnection.Close();

            return anunciosDaWeb;
        }

        public void AlterarAnuncioRepository(AnuncioWeb anuncioWeb)
        {
            int idAnuncioWeb = anuncioWeb.ID;

            var comando =
                $@"UPDATE {_tabelaAnuncio} 
                   SET marca = @marca, 
                        modelo = @modelo,
                        versao = @versao,
                        ano = @ano, 
                        quilometragem = @quilometragem,
                        observacao = @observacao
                   WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);

            sqlCommand.AdicionarParametrosDeAnuncio(
                anuncioWeb.Marca,
                anuncioWeb.Modelo,
                anuncioWeb.Versao,
                anuncioWeb.Ano,
                anuncioWeb.Quilometragem,
                anuncioWeb.Observacao);

            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idAnuncioWeb
            };
            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void ExcluirAnuncioRepository(int idAnuncioWeb)
        {
            var comando = $"DELETE FROM {_tabelaAnuncio} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idAnuncioWeb
            };

            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }


        public AnuncioWeb ObterAnuncioUnicoRepository(int idAnuncioWeb)
        {
            AnuncioWeb anunciosWeb = new AnuncioWeb();
            var comando = $"SELECT * FROM {_tabelaAnuncio} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idAnuncioWeb
            };
            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                anunciosWeb.ID = (int)resultado["ID"];
                anunciosWeb.Marca = resultado["marca"].ToString();
                anunciosWeb.Modelo = resultado["modelo"].ToString();
                anunciosWeb.Versao = resultado["versao"].ToString();
                anunciosWeb.Ano = (int)resultado["ano"];
                anunciosWeb.Quilometragem = (int)resultado["quilometragem"];
                anunciosWeb.Observacao = resultado["observacao"].ToString();
            }

            _sqlConnection.Close();

            return anunciosWeb;
        }
    }
}

public static class Helper
{
    public static SqlCommand AdicionarParametrosDeAnuncio(
        this SqlCommand comando,
        string Marca,
        string Modelo,
        string Versao,
        int Ano,
        int Quilometragem,
        string Observacao)
    {
        var parametroMarca = new SqlParameter()
        {
            ParameterName = "@marca",
            Value = Marca
        };
        parametroMarca.Value = (Marca != null) ? Marca : DBNull.Value;

        var parametroModelo = new SqlParameter()
        {
            ParameterName = "@modelo"
        };
        parametroModelo.Value = (Modelo != null) ? Modelo : DBNull.Value;

        var parametroVersao = new SqlParameter()
        {
            ParameterName = "@versao"
        };
        parametroVersao.Value = (Versao != null) ? Versao : DBNull.Value;

        var parametroAno = new SqlParameter()
        {
            ParameterName = "@ano",
            Value = Ano
        };

        var parametroQuilometragem = new SqlParameter()
        {
            ParameterName = "@quilometragem",
            Value = Quilometragem
        };

        var parametroObservacao = new SqlParameter()
        {
            ParameterName = "@observacao"
        };
        parametroObservacao.Value = (Observacao != null) ? Observacao : DBNull.Value;

        comando.Parameters.Add(parametroMarca);
        comando.Parameters.Add(parametroModelo);
        comando.Parameters.Add(parametroVersao);
        comando.Parameters.Add(parametroAno);
        comando.Parameters.Add(parametroQuilometragem);
        comando.Parameters.Add(parametroObservacao);

        return comando;
    }
}
