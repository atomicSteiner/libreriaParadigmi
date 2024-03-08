using libreriaParadigmi.Application.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaParadigmi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }
        [HttpGet]
        [Route("get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetLibri()
        {
            return Ok();
        }
    }
}
