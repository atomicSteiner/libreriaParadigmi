using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Models.Requests;
using libreriaParadigmi.Application.Models.Responses;
using libreriaParadigmi.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace libreriaParadigmi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_utenteService.Register(request.Nome, request.Cognome,request.Password, request.Email))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _utenteService.Login(request.Email, request.Password);
            if (token != null)
            {
                return Ok(ResponseFactory.WithSuccess(new LoginResponse(token)));
            }
            else
            {
                return Unauthorized();
            }
        }   

    }
}
