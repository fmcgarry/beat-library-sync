using Beansaber.Api;
using Beansaber.Api.Data;
using Beansaber.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options =>
{
	options.LowercaseUrls = true;
});

builder.Services.AddOptions<CosmosDbAccessOptions>()
	.Bind(builder.Configuration.GetSection("CosmosDb"))
	.ValidateDataAnnotations()
	.ValidateOnStart();

if (builder.Configuration.GetValue<bool>("Features:Database:UseInMemory"))
{
	builder.Services.AddSingleton<IDbAccess, MemoryDbAccess>();
}
else
{
	builder.Services.AddSingleton<IDbAccess, CosmosDbAccess>();
}

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
