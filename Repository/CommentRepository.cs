using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Data;
using api_tutorial.Interfaces;
using api_tutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace api_tutorial.Repository
{
    
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }
    }
}