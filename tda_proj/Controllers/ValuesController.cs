using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using tda_proj.Service;
using tda_proj.Service.LectorServiceApi;


namespace tda_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILectorServiceApi _lectorserviceAPI;

        public ValuesController(ILectorServiceApi lectorserviceAPI)
        {
            _lectorserviceAPI = lectorserviceAPI;
        }

        //Získání záznamů všech lektorů
        [HttpGet]
        public async Task<ActionResult<List<Lector>>> GetAllLectorsapi()
        {
            return await _lectorserviceAPI.GetAllLectorsapi();
        }

        //Dle UUID najde lektora a vrátí jeho údaje
        [HttpGet("{UUID}")]
        public async Task<ActionResult<Lector>> GetLectorByUUIDapi(Guid UUID)
        {
            var result = await _lectorserviceAPI.GetLectorByUUIDapi(UUID);
            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }


        //Dodělat u zbývajících requestů error messages
        [HttpPost]
        public async Task<ActionResult<List<Lector>>> AddLectorapi(Lector lector)
        {
            var result = await _lectorserviceAPI.AddLectorapi(lector);
            return Ok(result);
        }

        [HttpPut("{UUID}")]
        public async Task<ActionResult<Lector>> UpdateLectorByUUIDapi(Guid UUID, Lector request)
        {
           var result = await _lectorserviceAPI.UpdateLectorByUUIDapi(UUID, request);
            if (result is null) 
                return NotFound("User not found");

            return Ok(result);
        }

        [HttpDelete("{UUID}")]
        public async Task<ActionResult<Lector>> DeleteLectorByUUIDapi(Guid UUID, Lector request)
        {

            var result = await _lectorserviceAPI.DeleteLectorByUUIDapi(UUID, request);
            if (result is null)
                return NotFound("User not found");
            
            return Ok(result);
        }

    }
}
