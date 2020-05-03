using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MLCApi.Mappers;
using MLCApi.Models;
using MLCApi.Models.ApiModels;
using MLCApi.Services;

namespace MLCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        
        /// <summary>
        /// Get Marca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Marca = await _marcaService.GetMarca(id);

            return Ok(Marca);
        } 

        [HttpGet]
        [Produces("application/json", Type = typeof(List<Marca>))]
        public async Task<IActionResult> GetAll()
        {
            var Marca = await _marcaService.GetAllMarca();

            return Ok(Marca);
        }


        /// <summary>
        /// Agrega una Marca
        /// </summary>
        /// <param name="Marca"></param>
        /// <returns>Vendedor</returns>
        [ProducesResponseType(200)] 
        [ProducesResponseType(500)] 
        [ProducesResponseType(401)] 
        [Produces("application/json",Type=typeof(Marca))] 

        // POST: api/Values
        [HttpPost]
        public async Task<IActionResult> AddMarca([FromBody]Marca marca)
        {
            var name = await _marcaService.AddMarca(MarcaMapper.Map(marca));

            return Ok(name);
        }

        /// <summary>
        /// Actualiza una Marca
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        // PUT: api/Values/5
        [HttpPut]
        public async Task<IActionResult> UpdateMarca([FromBody]Marca marca)
        {
            var name = await _marcaService.UpdateMarca(MarcaMapper.Map(marca));

            return Ok(name);
        }
        /// <summary>
        /// Borra una Marca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
           await _marcaService.DeleteMarca(id);

            return Ok();
        }
    }
}
