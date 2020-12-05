using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secretary.Application.Abstract;
using Secretary.Application.DTOs.Requests;
using Secretary.Application.DTOs.Responses;
using Secretary.Domain;
using Secretary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secretary.Application.Services
{
    public class CrowdService : ICrowdService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CrowdService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CrowdResponseDTO>> GetCrowds(GetCrowdsRequestDTO request)
        {
            var query = _dbContext.Crowds.AsQueryable();
            
            if (request.Date.HasValue)
                query = query.Where(p => p.Timestamp.Year == request.Date.Value.Year && p.Timestamp.Month == request.Date.Value.Month && p.Timestamp.Day == request.Date.Value.Day);

            return _mapper.Map<List<CrowdResponseDTO>>(await query.ToListAsync());   
        }

        public async Task CreateRandomCrowds(int count)
        {
            Random random = new Random();
            for (int i = 1; i <= count; i++)
            {
                await _dbContext.AddAsync(new Crowd()
                {
                    Longitude = 69 + random.NextDouble(),
                    Latitude = 41 + random.NextDouble(),
                    Timestamp = DateTime.UtcNow
                });
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
