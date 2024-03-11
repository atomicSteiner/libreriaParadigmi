using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Models.DTO;
using libreriaParadigmi.Application.Models.Requests;
using libreriaParadigmi.Application.Models.Responses;
using libreriaParadigmi.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaParadigmi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddLibro([FromBody] AddLibroRequest addLibroRequest)
        {
            if(_libroService.AddLibro(addLibroRequest.nome, addLibroRequest.autore, addLibroRequest.editore,addLibroRequest.dataPubblicazione, addLibroRequest.categorie))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult RemoveLibro([FromBody] DeleteLibroRequest deleteLibroRequest)
        {
            if(_libroService.RemoveLibro(deleteLibroRequest.id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateLibro([FromBody] UpdateLibroRequest updateLibroRequest)
        {
            if(_libroService.UpdateLibro(updateLibroRequest.id,updateLibroRequest.nome, updateLibroRequest.autore, updateLibroRequest.editore, updateLibroRequest.dataPubblicazione, updateLibroRequest.categorie))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("list")]
        public IActionResult SearchLibri([FromBody] SearchLibroRequest searchLibroRequest)
        {
            int totalnum=0;
            var libri = _libroService.GetLibri(searchLibroRequest.categoria, searchLibroRequest.nome, searchLibroRequest.autore, searchLibroRequest.data, searchLibroRequest.from, searchLibroRequest.size, out totalnum);
            var response = new SearchLibroResponse();
            response.NumeroPagine= (int)Math.Ceiling((double)totalnum/searchLibroRequest.size);
            response.Libri= libri.Select(l => new LibroDTO(l)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
