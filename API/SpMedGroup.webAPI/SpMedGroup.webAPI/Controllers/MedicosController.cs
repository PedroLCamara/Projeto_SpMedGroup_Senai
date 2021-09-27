using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedGroup.webAPI.Domains;
using SpMedGroup.webAPI.Interfaces;
using SpMedGroup.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGroup.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MRepositorio { get; set; }

        public MedicosController()
        {
            MRepositorio = new MedicoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]    
        public IActionResult Cadastrar(Medico NovoMedico)
        {
            try
            {
                MRepositorio.Cadastrar(NovoMedico);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(MRepositorio.ListarTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpGet("{IdMedico}")]
        [Authorize(Roles = "1,3")]
        public IActionResult BuscarPorId(int IdMedico)
        {
            try
            {
                if (MRepositorio.BuscarPorId(IdMedico) != null)
                {
                    return Ok(MRepositorio.BuscarPorId(IdMedico));
                }
                else return NotFound("Id de médico inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpDelete("{IdMedicoDeletado}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int IdMedicoDeletado)
        {
            try
            {
                if (MRepositorio.BuscarPorId(IdMedicoDeletado) != null)
                {
                    MRepositorio.Deletar(IdMedicoDeletado);
                    return NoContent();
                }
                else return NotFound("Id de médico inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut("{IdMedicoAtualizado}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int IdMedicoAtualizado, Medico MedicoAtualizado)
        {
            try
            {
                if (MRepositorio.BuscarPorId(IdMedicoAtualizado) != null)
                {
                    MRepositorio.Atualizar(MedicoAtualizado, IdMedicoAtualizado);
                    return NoContent();
                }
                else return NotFound("Id de médico inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}
