using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blobupload.api.Models;

namespace blobupload.api.Services
{
    public interface IFileService
    {
        Task Upload(FileModels fileModels);
    }
}