using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TesteWebMotors.Dominio.Models;
using TesteWebMotors.Dominio.Repositories;

namespace TesteWebMotors.Dominio.Services
{

    public class AnuncioWebService
    {
        private AnuncioWebRepository _anuncioRepository;
        private AnuncioAPIMakeService _anuncioAPIMakeService;

        public AnuncioWebService(IConfiguration configuration)
        {
            _anuncioRepository = new AnuncioWebRepository(configuration);
            _anuncioAPIMakeService = new AnuncioAPIMakeService(configuration);
        }

        public void AdicionarAnuncios(AnuncioWeb anuncioWeb)
        {
            _anuncioRepository.AdicionarAnuncioRepository(anuncioWeb);
        }

        public List<AnuncioWeb> ConsultarAnuncios()
        {
            var listaDeAnuncio = _anuncioRepository.ObterAnuncioRepository();
            return listaDeAnuncio;
        }

        public void AlterarAnuncio(AnuncioWeb anuncioWeb)
        {
            _anuncioRepository.AlterarAnuncioRepository(anuncioWeb);
        }

        public void ExcluirAnuncios(int idAnuncioWeb)
        {
            _anuncioRepository.ExcluirAnuncioRepository(idAnuncioWeb);
        }

        public AnuncioWeb ConsultarUnicoAnuncios(int idAnuncioWeb)
        {
            var consultaUnica = _anuncioRepository.ObterAnuncioUnicoRepository(idAnuncioWeb);
            return consultaUnica;
        }
    }
}