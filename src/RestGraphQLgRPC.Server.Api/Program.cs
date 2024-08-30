using RestGraphQLgRPC.Server.Api.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add GraphQL Configuration
builder.Services.AddGraphQLConfig();

// Add gRPC Configuration
builder.Services.AddgRPCConfig();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.MapGrpcReflectionService();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use GraphQL
app.UseGraphQL();

// Use gRPC
app.UsegRPC();

app.MapControllers();

app.Run();