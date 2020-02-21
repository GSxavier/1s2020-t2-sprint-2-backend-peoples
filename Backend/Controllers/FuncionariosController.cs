using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_Peoples.Domains;
using T_Peoples.Interfaces;
using T_Peoples.Repositories;

namespace T_Peoples.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionario _funcionariosRepository { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {

            return _funcionariosRepository.Listar();
        }
    }
}