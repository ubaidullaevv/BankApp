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
    public async Task<Response<List<Loan>>> GetResponses()
    {
        var response=LoanService.GetLoans();
        return await response;
    }
    [HttpPost]
    public async Task<Response<bool>> AddLoan(Loan loan)
    {
        var response=LoanService.AddLoan(loan);
        return await response;
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Loan loan)
    {
        var response=LoanService.UpdateLoan(loan);
        return await response;
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        var response=LoanService.DeleteLoan(id);
        return await response;
    }
    [HttpGet ("get-by-id")]
    public async Task<Response<Loan>> GetById(int id)
    {
        var response=LoanService.GetLoanById(id);
        return await response;
    }
    [HttpPost("amount-limit")]
    public async Task<Response<bool>> AmountLimit(Loan loan)
    {
        var response=LoanService.AmountLimit(loan);
        return await response;
    }
}
