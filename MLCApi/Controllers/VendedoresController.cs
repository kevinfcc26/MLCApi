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
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedoresService _vendedoresService;

        public VendedoresController(IVendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }
        
        // GET: api/Values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var name = await _vendedoresService.GetVendedoresName(id);

            return Ok(name);
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
            var name = await _vendedoresService.AddAdmin(VendedorMapper.Map(vendedor));

            return Ok(name);
        }
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
