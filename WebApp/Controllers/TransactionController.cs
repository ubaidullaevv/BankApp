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
    public Response<List<Transaction>> GetResponses()
    {
        var response=TransactionService.GetTransactions();
        return response;
    }
    [HttpPost]
    public Response<bool> AddTransaction(Transaction transaction)
    {
        var response=TransactionService.AddTransaction(transaction);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Transaction transaction)
    {
        var response=TransactionService.UpdateTransaction(transaction);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=TransactionService.DeleteTransaction(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Transaction> GetById(int id)
    {
        var response=TransactionService.GetTransactionById(id);
        return response;
    }
}
