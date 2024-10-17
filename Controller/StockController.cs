using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Models;
using api_tutorial.Data;
using Microsoft.AspNetCore.Mvc;
using api_tutorial.Mappers;
using api_tutorial.Dtos.Stock; 
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using api_tutorial.Interfaces;

namespace api_tutorial.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {   

        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var stocks = await _stockRepo.GetAllAsync();

            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null) {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){
            
            var stockModel = stockDto.ToStockFromCreateDto();

            await _stockRepo.CreateAsync(stockModel);
            
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        } 

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
            
            if(stockModel == null) {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto()); 
        }
        [HttpDelete] 
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            
            var stockModel = await _stockRepo.DeleteAsync(id);

            if(stockModel == null) {
                return NotFound();
            }


            return NoContent();
        }
    }
}