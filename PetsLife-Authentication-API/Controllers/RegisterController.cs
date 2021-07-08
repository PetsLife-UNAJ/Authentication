using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Authentication_API.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterClienteController : ControllerBase
    {
        private readonly IAutenticationService _service;
        public RegisterClienteController(IAutenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RequestRegisterDto userInfo)
        {
            try
            {
                return new JsonResult(_service.RegisterUser(userInfo)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    [ApiController]
    [Route("api/register/veterinario")]
    public class RegisterProfesionalController : ControllerBase
    {
        private readonly IAutenticationService _service;
        public RegisterProfesionalController(IAutenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RequestRegisterDto userInfo)
        {
            try
            {
                return new JsonResult(_service.RegisterVeterinario(userInfo)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    [ApiController]
    [Route("api/register/administrador")]
    public class RegisterAdministradorController : ControllerBase
    {
        private readonly IAutenticationService _service;
        public RegisterAdministradorController(IAutenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RequestRegisterDto userInfo)
        {
            try
            {
                return new JsonResult(_service.RegisterAdministrador(userInfo)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}