using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_tutorial.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_tutorial.Models
{
    [Table("Stocks")]
    public class Stock
    {
        
        public int Id { get; set; }

        [Column(TypeName ="text")]
        public string Symbol { get; set; } = string.Empty;
         [Column(TypeName ="text")]
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
         [Column(TypeName ="text")]
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<Comment> Comments {get; set;} = new List<Comment>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}