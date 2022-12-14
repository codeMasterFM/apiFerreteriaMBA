using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<apiFerreateriaMBA.Models.FerreteriaMBA1Context>(p => {

    p.UseSqlServer(builder.Configuration.GetConnectionString("context"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => { 

    p.AllowAnyHeader();
    p.AllowAnyMethod();
    p.AllowAnyOrigin();

});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
