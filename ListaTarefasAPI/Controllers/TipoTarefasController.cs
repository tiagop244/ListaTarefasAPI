﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaTarefasAPI.Data;
using ListaTarefasAPI.Models;

namespace ListaTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTarefasController : ControllerBase
    {
        private readonly ListaTarefasContext _context;

        public TipoTarefasController(ListaTarefasContext context)
        {
            _context = context;
        }

        // GET: api/TipoTarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTarefa>>> GetTiposTarefa()
        {
            return await _context.TiposTarefa.ToListAsync();
        }

        // GET: api/TipoTarefas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTarefa>> GetTipoTarefa(int id)
        {
            var tipoTarefa = await _context.TiposTarefa.FindAsync(id);

            if (tipoTarefa == null)
            {
                return NotFound();
            }

            return tipoTarefa;
        }

        // PUT: api/TipoTarefas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTarefa(int id, TipoTarefa tipoTarefa)
        {
            if (id != tipoTarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoTarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoTarefas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTarefa>> PostTipoTarefa(TipoTarefa tipoTarefa)
        {
            _context.TiposTarefa.Add(tipoTarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTarefa", new { id = tipoTarefa.Id }, tipoTarefa);
        }

        // DELETE: api/TipoTarefas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTarefa(int id)
        {
            var tipoTarefa = await _context.TiposTarefa.FindAsync(id);
            if (tipoTarefa == null)
            {
                return NotFound();
            }

            _context.TiposTarefa.Remove(tipoTarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTarefaExists(int id)
        {
            return _context.TiposTarefa.Any(e => e.Id == id);
        }
    }
}
