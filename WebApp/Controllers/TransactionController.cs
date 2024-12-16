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
public class TransactionController(ITransactionService TransactionService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Transaction>>> GetResponses()
    {
        var response=TransactionService.GetTransactions();
        return await response;
    }
    [HttpPost]
    public async Task<Response<bool>> AddTransaction(Transaction transaction)
    {
        var response=TransactionService.AddTransaction(transaction);
        return await response;
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Transaction transaction)
    {
        var response=TransactionService.UpdateTransaction(transaction);
        return await response;
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        var response=TransactionService.DeleteTransaction(id);
        return await response;
    }
    [HttpGet ("get-by-id")]
    public async Task<Response<Transaction>> GetById(int id)
    {
        var response=TransactionService.GetTransactionById(id);
        return await response;
    }
}
