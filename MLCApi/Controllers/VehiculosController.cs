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
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculosService _vehiculosService;

        public VehiculosController(IVehiculosService vehiculosService)
        {
            _vehiculosService = vehiculosService;
        }

        /// <summary>
        /// Get vehiculos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehiculos = await _vehiculosService.GetVehiculos(id);

            return Ok(vehiculos);
        } 

        [HttpGet]
        [Produces("application/json", Type = typeof(List<Vehiculos>))]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _vehiculosService.GetAllVehiculos();

            return Ok(vehiculos);
        }


        /// <summary>
        /// Agrega un nuevo Vendedor
        /// </summary>
        /// <param name="vehiculos"></param>
        /// <returns>Vendedor</returns>
        [ProducesResponseType(200)] 
        [ProducesResponseType(500)] 
        [ProducesResponseType(401)] 
        [Produces("application/json",Type=typeof(Vehiculos))] 

        // POST: api/Values
        [HttpPost]
        public async Task<IActionResult> AddVehiculos([FromBody]Vehiculos vehiculos)
        {
            var name = await _vehiculosService.AddVehiculos(VehiculosMapper.Map(vehiculos));

            return Ok(name);
        }

        /// <summary>
        /// Actualiza un Vehiculos
        /// </summary>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        // PUT: api/Values/5
        [HttpPut]
        public async Task<IActionResult> UpdateVehiculos([FromBody]Vehiculos vehiculos)
        {
            var name = await _vehiculosService.UpdateVehiculos(VehiculosMapper.Map(vehiculos));

            return Ok(name);
        }
        /// <summary>
        /// Borra un Vehiculos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)
        {
            await _vehiculosService.DeleteVehiculos(id);

            return Ok();
        }
    }
}
