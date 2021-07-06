using AccessData.Queries.Repository;
using Domain.Commands;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Application.Services
{
    public interface IAutenticationService
    {
        ResponseUserDto RegisterUser(RequestRegisterDto userInfo, int rol = Constants.CLIENTE);
        ResponseUserDto RegisterVeterinario(RequestRegisterDto userInfo);
        ResponseUserDto RegisterAdministrador(RequestRegisterDto userInfo);
        ResponseLoginDto Login(RequestLoginDto userInfo);
    }
    public class AutenticationService : IAutenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository _repository;
        private readonly IAutenticationQuery _query;
        public AutenticationService(IConfiguration configuration, IGenericRepository repository, IAutenticationQuery query)
        {
            _repository = repository;
            _query = query;
            _configuration = configuration;
        }

        public ResponseUserDto RegisterUser(RequestRegisterDto userInfo, int rol = Constants.CLIENTE)
        {
            Usuario entity = new Usuario
            {
                Nombres = userInfo.Nombres,
                Apellidos = userInfo.Apellidos,
                DNI = userInfo.DNI,
                Sexo = userInfo.Sexo,
                Email = userInfo.Email,
                Telefono = userInfo.Telefono,
                Password = Utils.Encryption(userInfo.Password),
                RolId = rol
            };

            _repository.Add<Usuario>(entity);

            _repository.SaveChanges();
            return new ResponseUserDto
            {
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                DNI = entity.DNI,
                Sexo = entity.Sexo,
                Email = entity.Email,
                Telefono = entity.Telefono,
                RolId = entity.RolId
            };
        }

        public ResponseUserDto RegisterVeterinario(RequestRegisterDto userInfo)
        {
            return RegisterUser(userInfo, Constants.VETERINARIO);
        }

        public ResponseUserDto RegisterAdministrador(RequestRegisterDto userInfo)
        {
            return RegisterUser(userInfo, Constants.ADMINISTRADOR);
        }

        public ResponseLoginDto Login(RequestLoginDto userInfo)
        {
            Usuario user = _query.GetUserByEmail(userInfo.Email);

            if (user != null && user.Password == Utils.Encryption(userInfo.Password))
            {
                var secretKey = _configuration.GetSection("SecretKey").Value;
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new[]
                {
                    new Claim("User", JsonConvert.SerializeObject(user))
                };

                var identity = new ClaimsIdentity(new GenericIdentity(user.Email, "Auth"), claims);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    IssuedAt = DateTime.UtcNow
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                ResponseUserLoginDto usuarioResponse = new ResponseUserLoginDto
                {
                    Id = user.Id,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Email = user.Email,
                    RolId = user.RolId,
                };

                return new ResponseLoginDto { Token = tokenHandler.WriteToken(createdToken), Usuario = usuarioResponse };
            }

            throw new Exception("El Email o contraseña ingresado es incorrecto");
        }
    }
}