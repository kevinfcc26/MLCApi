﻿using System;
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
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedoresService _vendedoresService;

        public VendedoresController(IVendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }
        
        /// <summary>
        /// Get Vendedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Vendedor = await _vendedoresService.GetVendedores(id);

            return Ok(Vendedor);
        } 

        [HttpGet]
        [Produces("application/json", Type = typeof(List<Vendedor>))]
        public async Task<IActionResult> GetAll()
        {
            var Vendedor = await _vendedoresService.GetAllVendedores();

            return Ok(Vendedor);
        }


        /// <summary>
        /// Agrega un nuevo Vendedor
        /// </summary>
        /// <param name="vendedores"></param>
        /// <returns>Vendedor</returns>
        [ProducesResponseType(200)] 
        [ProducesResponseType(500)] 
        [ProducesResponseType(401)] 
        [Produces("application/json",Type=typeof(Vendedor))] 

        // POST: api/Values
        [HttpPost]
        public async Task<IActionResult> AddVendedor([FromBody]Vendedor vendedor)
        {
            var name = await _vendedoresService.AddVendedor(VendedorMapper.Map(vendedor));

            return Ok(name);
        }

        /// <summary>
        /// Actualiza un Vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        // PUT: api/Values/5
        [HttpPut]
        [Produces("application/json", Type = typeof(Vendedor))]
        public async Task<IActionResult> UpdateVendedor([FromBody]Vendedor vendedor)
        {
            var name = await _vendedoresService.UpdateVendedor(VendedorMapper.Map(vendedor));

            return Ok(name);
        }
        /// <summary>
        /// Borra un Vendedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            await _vendedoresService.DeleteVendedor(id);

            return Ok();
        }
    }
}
