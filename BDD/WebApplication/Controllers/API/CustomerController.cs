using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [Route("{Id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(new CustomerModel()
            {
                Id = id,
                CPF = "000.000.000-00",
                Email = "rafaelcruz.net81@gmail.com",
                DataNascimento = new DateTime(1981,03,13) ,
                Endereco = "Rua Teste de API",
                NomeCompleto = "Rafael Cruz"
            });
        }

        
        [HttpPost]
        public IHttpActionResult Post(CustomerModel model)
        {
            return Created(String.Empty, model);

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}