using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api_tutorial.Mappers;
using api_tutorial.Dtos.Stock;

namespace api_tutorial.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

    }
}