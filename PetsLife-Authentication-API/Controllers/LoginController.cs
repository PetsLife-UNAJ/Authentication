using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Authentication_API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAutenticationService _service;
        public LoginController(IAutenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RequestLoginDto userInfo)
        {
            try
            {
                return new JsonResult(_service.Login(userInfo)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}