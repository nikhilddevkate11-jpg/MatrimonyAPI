using Matrimony.Models.DTOs.Country;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCountryDto dto)
        {
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            return Ok(await _service.SearchAsync(keyword));
        }
    }
}
