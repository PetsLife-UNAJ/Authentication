﻿using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLife_Authentication_API.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterPacienteController : ControllerBase
    {
        private readonly IAutenticationService _service;
        public RegisterPacienteController(IAutenticationService service)
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
    //[Authorize]
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
    //[Authorize]
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