using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Infrastructore.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController(ILoanService LoanService):ControllerBase
{
    [HttpGet]
    public Response<List<Loan>> GetResponses()
    {
        var response=LoanService.GetLoans();
        return response;
    }
    [HttpPost]
    public Response<bool> AddLoan(Loan loan)
    {
        var response=LoanService.AddLoan(loan);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Loan loan)
    {
        var response=LoanService.UpdateLoan(loan);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=LoanService.DeleteLoan(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Loan> GetById(int id)
    {
        var response=LoanService.GetLoanById(id);
        return response;
    }
    [HttpPost("amount-limit")]
    public Response<bool> AmountLimit(Loan loan)
    {
        var response=LoanService.AmountLimit(loan);
        return response;
    }
}
