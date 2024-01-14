using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using tda_proj.Service;
using tda_proj.Service.LectorService;


namespace tda_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILectorService _lectorserviceAPI;

        public ValuesController(ILectorService lectorserviceAPI)
        {
            _lectorserviceAPI = lectorserviceAPI;
        }

        //Získání záznamů všech lektorů
        [HttpGet]
        public async Task<ActionResult<List<Lector>>> GetAllLectors()
        {
            return await _lectorserviceAPI.GetAllLectors();
        }

        //Dle UUID najde lektora a vrátí jeho údaje
        [HttpGet("{UUID}")]
        public async Task<ActionResult<Lector>> GetLectorByUUID(Guid UUID)
        {
            var result = await _lectorserviceAPI.GetLectorByUUIDapi(UUID);
            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }


        //Dodělat u zbývajících requestů error messages
        [HttpPost]
        public async Task<ActionResult<List<Lector>>> AddLector(Lector lector)
        {
            var result = await _lectorserviceAPI.AddLector(lector);
            return Ok(result);
        }

        [HttpPut("{UUID}")]
        public async Task<ActionResult<Lector>> UpdateLectorByUUID(Guid UUID, Lector request)
        {
           var result = await _lectorserviceAPI.UpdateLectorByUUID(UUID, request);
            if (result is null) 
                return NotFound("User not found");

            return Ok(result);
        }

        [HttpDelete("{UUID}")]
        public async Task<ActionResult<Lector>> DeleteLectorByUUID(Guid UUID, Lector request)
        {

            var result = await _lectorserviceAPI.DeleteLectorByUUID(UUID, request);
            if (result is null)
                return NotFound("User not found");
            
            return Ok(result);
        }

    }
}
