using DatingApp.AutoMapper;
using DatingApp.Data.Context;
using DatingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatingAppContext>(options=>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DatingApp")));
builder.Services.AddScoped<IAppUserAppService,AppUserAppService>();
builder.Services.AddAutoMapper(e=>e.AddProfile<DatingAppProfile>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
