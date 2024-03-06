using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Options;
using libreriaParadigmi.Models.Entities;
using libreriaParadigmi.Models.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public UtenteService(UtenteRepository utenteRepository, IOptions<JwtAuthenticationOption>jwtAuthenticationOption)
        {
            _utenteRepository = utenteRepository;
            _jwtAuthOption = jwtAuthenticationOption.Value;
        }
        public Utente GetUtente(string id)
        {
            throw new NotImplementedException();
        }

        public string Login(string mail, string password)
        {
            if (_utenteRepository.checkMailPassword(mail, password))
            {
                return GenerateJwtToken(_utenteRepository.GetByEmail(mail));
            }
            else
            {
                return null;
            }
        }
        private string GenerateJwtToken(Utente u)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, u.nome),
                new Claim(ClaimTypes.Email, u.email),
                new Claim("Id", u.id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securtyyoken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(securtyyoken);
        }

        public bool Register(string nome, string cognome, string password, string mail)
        {
            if(_utenteRepository.GetByEmail(mail) != null)
            {
                return false;
            }
            Utente u = new Utente(nome, cognome, mail, password);
            _utenteRepository.Add(u);
            _utenteRepository.Save();
            return true;
        }
    }
}
