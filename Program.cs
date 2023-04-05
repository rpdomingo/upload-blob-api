using Azure.Storage.Blobs;
using blobupload.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(_ => {
    return new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage"));
});

builder.Services.AddScoped<IFileService, FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Development.API.Integration v1"));
} 
else {
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevelopmentAz.API.Integration v1"));
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
