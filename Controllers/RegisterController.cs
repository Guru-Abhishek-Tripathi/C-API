using ApiRegister.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterRepository registerRepository;
        public RegisterController()
        {
            registerRepository = new RegisterRepository();
        }

        [HttpPost]
        public void Post([FromBody] Register prod)
        {
            if(ModelState.IsValid)
            {
                registerRepository.Add(prod);
            }
        }

        [HttpGet]
        public IEnumerable<Register> Get()
        {
            return registerRepository.GetAll();
        }
    }
}
