﻿using Secretary.Application.DTOs.Requests;
using Secretary.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Secretary.Application.Abstract
{
    public interface IRecognitionService
    {
        Task<RecognitionResponseDTO> Recognize(RecognitionRequestDTO dto, CancellationToken cancellationToken = default);
    }
}
