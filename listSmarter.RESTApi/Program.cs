using ListSmarter;
using AutoMapper.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.RegisterValidators();
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ListSmarter.RESTApi", Version = "v1" });
});

// Add AutoMapper configuration
builder.Services.AddAutoMapper((config) => { }, AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ListSmarter.RESTApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();