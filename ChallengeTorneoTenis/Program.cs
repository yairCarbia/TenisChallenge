using TorneoTenis.Business.Implementacion;
using TorneoTenis.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Business
builder.Services.AddScoped<ITorneoBusiness, TorneoBusiness>();
builder.Services.AddScoped<IPartidoBusiness, PartidoBusiness>();
builder.Services.AddScoped<ITorneoAuditoriaBusiness, TorneoAuditoriaBusiness>();
#endregion

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
