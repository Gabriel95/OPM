using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpmInterfaces.Interfaces;

namespace ExpedienteClientes.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public ValuesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET api/values
        [Authorize]
        public IEnumerable<string> Get()
        {
            var names = _userRepository.GetAllUsers().Select(x => x.FirstName).ToArray();
            return names;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
