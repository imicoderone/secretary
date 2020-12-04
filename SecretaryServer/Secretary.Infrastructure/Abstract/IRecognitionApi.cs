using Secretary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Secretary.Infrastructure.Abstract
{
    public interface IRecognitionApi
    {
        Task<RecognitionResponseModel> Recognize(byte[] file, string languageCode, CancellationToken cancellationToken = default);
    }
}
