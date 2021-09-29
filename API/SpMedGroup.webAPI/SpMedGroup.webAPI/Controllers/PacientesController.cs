﻿using Microsoft.AspNetCore.Authorization;
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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository PRepositorio { get; set; }

        public PacientesController()
        {
            PRepositorio = new PacienteRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Paciente NovoPaciente)
        {
            try
            {
                PRepositorio.Cadastrar(NovoPaciente);
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
                return Ok(PRepositorio.ListarTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpGet("{IdPaciente}")]
        [Authorize(Roles = "1,2")]
        public IActionResult BuscarPorId(int IdPaciente)
        {
            try
            {
                if (PRepositorio.BuscarPorId(IdPaciente) != null)
                {
                    return Ok(PRepositorio.BuscarPorId(IdPaciente));
                }
                else return NotFound("Id de paciente inexistente");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
        
        [HttpDelete("{IdPacienteDeletado}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int IdPacienteDeletado)
        {
            try
            {
                if (PRepositorio.BuscarPorId(IdPacienteDeletado) != null)
                {
                    PRepositorio.Deletar(IdPacienteDeletado);
                    return NoContent();
                }
                else return NotFound("Id de paciente inexistente");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
        
        [HttpPut("{IdPacienteAtualizado}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int IdPacienteAtualizado, Paciente PacienteAtualizado)
        {
            try
            {
                if (PRepositorio.BuscarPorId(IdPacienteAtualizado) != null)
                {
                    PRepositorio.Atualizar(PacienteAtualizado, IdPacienteAtualizado);
                    return NoContent();
                }
                else return NotFound("Id de paciente inexistente");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}
