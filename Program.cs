using _6lr;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICompaniesService, CompaniesService>();//об'єкт сервісу створюється при першому зверненні до нього, всі наступні запити використовують той самий раніше створений об'єкт сервісу
builder.Services.AddSingleton<IPhonesService, PhonesService>();//об'єкт сервісу створюється при першому зверненні до нього, всі наступні запити використовують той самий раніше створений об'єкт сервісу
builder.Services.AddSingleton<IUsersService, UsersService>();//об'єкт сервісу створюється при першому зверненні до нього, всі наступні запити використовують той самий раніше створений об'єкт сервісу

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "lr7");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
