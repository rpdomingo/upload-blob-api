using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blobupload.api.Models;
using blobupload.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace blobupload.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] FileModels file)
        {
            await  _fileService.Upload(file);
            return Ok("Success");
        }
    }
}