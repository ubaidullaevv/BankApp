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
    public async  Task<Response<List<Account>>> GetResponses()
    {
        var response=AccountService.GetAccounts();
        return await response;
    }
    [HttpPost]
    public async Task<Response<bool>> AddAccount(Account account)
    {
        var response=AccountService.AddAccount(account);
        return await response;
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Account account)
    {
        var response=AccountService.UpdateAccount(account);
        return await response;
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        var response=AccountService.DeleteAccount(id);
        return await response;
    }
    [HttpGet ("get-by-id")]
    public async Task<Response<Account>> GetById(int id)
    {
        var response=AccountService.GetAccountById(id);
        return await response;
    }

    // [HttpPut("update-status")]
    
    // public Response<bool> UpdateStatus(int id,string status)
    // {
    //     var response=AccountService.UpdateStatus(id,status);
    //     return response;
    // }

}
