using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class AccountService(DapperContext _context) : IAccountService
{
   public Response<bool> AddAccount(Account account)
    {
        using var context=_context.Connection();
        string cmd="insert into Accounts(customerid,balance,accountstatus,accounttype,currency,created_at,deleted_at)values(@CustomerId,@Balance,@AccountStatus,@AccountType,@Currency,@Created_at,@Deleted_at)";
        var res=context.Execute(cmd,account);
        if(account==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteAccount(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Accounts where Accountid=@AccountId";
        var res=context.Execute(cmd,new {AccountId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Account> GetAccountById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Accounts where Accountid=@AccountId";
        var res=context.Query<Account>(cmd,new {AccountId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Account>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<Account>(res);
    }

    public Response<List<Account>> GetAccounts()
    {
        using var context=_context.Connection();
        string cmd="select * from Accounts";
        var res=context.Query<Account>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Account>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Account>>(res);
    }

    public Response<bool> UpdateAccount(Account Account)
    {
        using var context=_context.Connection();
        string cmd="update  Accounts set accountid=@AccountId ,customerid=@CustomerId,balance=@Balance,accountstatus=@AccountStatusaccounttype=,@AccountType,currency=@Currency,created_at=@Created_at,deleted_at=@Deleted_at";
        var res=context.Execute(cmd,Account);
        if(Account==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    // public Response<bool> UpdateStatus(int id,string status)
    // {
    //     using var context=_context.Connection();
    //     string cmd="update accounts set accountstatus=@AccountStatus where accountid=AccountId";
    //     var res=context.Execute(cmd,new {AccountStatus=status} , new {AccountId=id});
    //     if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
    //     return new Response<bool>(res>0);
    // }
}


