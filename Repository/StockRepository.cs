using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Interfaces;
using api_tutorial.Models;

namespace api_tutorial.Repository
{
    public class StockRepository : IStockRepository
    {
        public Task<List<Stock>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}