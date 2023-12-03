using CommunicationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommunication(o =>
{
    o.emailConfig = new EmailConfig()
    {
        
        Host = "mail.blueboxbc.com",
        Password = "7ae3bf43-b370-4e28-92fc-880e5f66d1ed",
        Port = 587,
        UserName = "test@blueboxbc.com",
        From = "test@blueboxbc.com"

    };
    o.smsConfig = new SMSConfig()
    {
        password = "4#EH@",
        username = "9120198177",
        PaternId= 175227
    };
});
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
