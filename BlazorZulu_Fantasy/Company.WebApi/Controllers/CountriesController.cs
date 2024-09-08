using Company.Shared.Entities;
using Company.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.WebApi.Controllers
{    
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        //CONSTRUCTOR
        public CountriesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {            
            return Ok(await _dbContext.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _dbContext.Add(country);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            var currentCountry = await _dbContext.Countries.FindAsync(country.Id);
            if (currentCountry == null)
            {
                return NotFound();
            }        
            currentCountry.Name = country.Name;
            _dbContext.Update(currentCountry);
            await _dbContext.SaveChangesAsync();
            return NoContent();    
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }            
            _dbContext.Remove(country);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

