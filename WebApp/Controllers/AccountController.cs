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
public class AccountController(IAccountService AccountService):ControllerBase
{
    [HttpGet]
    public Response<List<Account>> GetResponses()
    {
        var response=AccountService.GetAccounts();
        return response;
    }
    [HttpPost]
    public Response<bool> AddAccount(Account account)
    {
        var response=AccountService.AddAccount(account);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Account account)
    {
        var response=AccountService.UpdateAccount(account);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=AccountService.DeleteAccount(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Account> GetById(int id)
    {
        var response=AccountService.GetAccountById(id);
        return response;
    }

    // [HttpPut("update-status")]
    
    // public Response<bool> UpdateStatus(int id,string status)
    // {
    //     var response=AccountService.UpdateStatus(id,status);
    //     return response;
    // }

}
