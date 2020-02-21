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


        [HttpPost]
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {

            _funcionariosRepository.Cadastrar(novoFuncionario);

            
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);


            if (funcionarioBuscado == null)
            {

                return NotFound("Não foi possivel encotrar funcionario");
            }


            return Ok(funcionarioBuscado);
        }


        [HttpPut]
        public IActionResult PutIdCorpo(FuncionariosDomain funcionarioAtualizado)
        {

            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(funcionarioAtualizado.IdFuncionarios);


            if (funcionarioBuscado != null)
            {

                try
                {

                    _funcionariosRepository.AtualizarIdCorpo(funcionarioAtualizado);


                    return NoContent();
                }

                catch (Exception erro)
                {

                    return BadRequest(erro);
                }

            }


            return NotFound
                (
                    new
                    {
                        mensagem = "Não foi possivel acahar funcionarios",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _funcionariosRepository.Deletar(id);


            return Ok("Funcionario foi deletado");
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {

            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);


            if (funcionarioBuscado == null)
            {


                return NotFound
                    (
                        new
                        {
                            mensagem = "funcionario não encontrado",
                            erro = true
                        }
                    );
            }


            try
            {

                _funcionariosRepository.AtualizarIdUrl(id,funcionarioAtualizado);

                return NoContent();
            }

            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}