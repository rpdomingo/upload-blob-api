using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using blobupload.api.Models;

namespace blobupload.api.Services
{
    public class FileService: IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModels filemodel)
        {
            try
            {
                 var containerInstance = _blobServiceClient.GetBlobContainerClient("samplefileupload");

                var blobInstance = containerInstance.GetBlobClient(filemodel.ImageFile.FileName);

                await blobInstance.UploadAsync(filemodel.ImageFile.OpenReadStream());
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
           
        }
    }
}