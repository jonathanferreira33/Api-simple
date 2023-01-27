using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), 200)]
        public IActionResult Get()
        {
            try
            {
                var users = GetUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var users = GetUsers();

            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return Ok(user);
                }
            }
            return BadRequest();
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = Guid.Parse("CAEF4812-598E-4473-8EFC-B338AF69A18F"), Name = "João", Email = "joao@outlook.com" },
                new User { Id = Guid.Parse("B88DCCAF-A3A2-436F-8B09-27F0E1F73321"), Name = "José", Email = "jose@outlook.com" },
                new User { Id = Guid.Parse("1E018A4E-FC1B-4E2D-91CA-8076D60CF63F"), Name = "Maria", Email = "maria@outlook.com" }
            };
        }
    }
}
