using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Models;

namespace api_tutorial.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        
    }
}