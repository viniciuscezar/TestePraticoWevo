using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePraticoWevo.Model;
using TestePraticoWevo.Repositories;

namespace TestePraticoWevo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repository;

        public UsuarioController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var listUsuarios = await _repository.BuscarUsuarios();

                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var listUruariosId = await _repository.BuscarUsuarioId(id);

                return Ok(listUruariosId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/usuario
        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            try
            {

                _repository.Add(usuario);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Usuário cadastrado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Usuário não cadastrado!");
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            try
            {
                var selectUsuario = await _repository.BuscarUsuarioId(id);

                if (selectUsuario != null)
                {
                    _repository.Update(usuario);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Usuário Atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return Ok("Usuário não atualizado!");
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _repository.BuscarUsuarioId(id);

                if (usuario != null)
                {
                    _repository.Delete(usuario);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Usuário deletado com sucesso!");
                    }

                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Usuário não deletado!");
        }
    }
}
