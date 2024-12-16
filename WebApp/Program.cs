
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped<DapperContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebAPI1"));
}


app.UseCors();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();