using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TesteWebMotors.Dominio.Services;
using TesteWebMotors.Dominio.Models;
using System.Threading.Tasks;

namespace TesteWebMotors.Controllers
{
    public class AnunciosController : Controller
    {
        private AnuncioWebService _anuncioWebService;
        private AnuncioAPIMakeService _anuncioAPIMakeService;

        public AnunciosController(IConfiguration configuration)
        {
            _anuncioWebService = new AnuncioWebService(configuration);
            _anuncioAPIMakeService = new AnuncioAPIMakeService(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Adicionar()
        {
            var listaDeMarcas = await _anuncioAPIMakeService.ObterListaMarca();
            ViewData["AnuncioAPIMakes"] = listaDeMarcas;

            return View();
        }

        public IActionResult Gerenciar()
        {
            var listaDeCategorias = _anuncioWebService.ConsultarAnuncios();
            return View(listaDeCategorias);
        }

        [HttpPost]
        public IActionResult AdicionarAnuncio(AnuncioWeb anuncioWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Preencha os campos corretamente");
            }

            _anuncioWebService.AdicionarAnuncios(anuncioWeb);
            return Redirect("/Anuncios/Adicionar");
        }

        [Route("Anuncios/Deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _anuncioWebService.ExcluirAnuncios(id);
            return Redirect("/Anuncios/Gerenciar");
        }


        [HttpGet]
        [Route("Anuncios/Editar/{id}")]
        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            var anuncios = _anuncioWebService.ConsultarUnicoAnuncios(id);
            var listaDeMarcas = await _anuncioAPIMakeService.ObterListaMarca();
            ViewData["AnuncioAPIMakes"] = listaDeMarcas;
            return View(anuncios);
        }

        [HttpPost]
        [Route("Anuncios/Editar/{id}")]
        public IActionResult EditarAnuncios([FromRoute] int id, AnuncioWeb anuncioWeb)
        {
            if (ModelState.IsValid)
            {
                _anuncioWebService.AlterarAnuncio(anuncioWeb);
            }
            return Redirect("/Anuncios/Gerenciar/");
        }

    }
}
