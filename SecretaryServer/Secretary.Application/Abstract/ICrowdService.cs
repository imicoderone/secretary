using Secretary.Application.DTOs.Requests;
using Secretary.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Secretary.Application.Abstract
{
    public interface ICrowdService
    {
        Task<List<CrowdResponseDTO>> GetCrowds(GetCrowdsRequestDTO request);
        Task CreateRandomCrowds(int count);
    }
}
