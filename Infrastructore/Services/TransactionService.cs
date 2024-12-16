using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class TransactionService(DapperContext _context) : ITransactionService
{
   public Response<bool> AddTransaction(Transaction transaction)
    {
        using var context=_context.Connection();
        string cmd="insert into Transactions(fromaccountid,tomaccountid,issueddate,amount,transactionmedium,created_at,deleted_at)values(@FromAccountId,@TomAccountId,@IssuedDate,@Amount,@TransactionMedium,@Created_at,@Deleted_at)";
        var res=context.Execute(cmd,transaction);
        if(transaction==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteTransaction(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Transactions where Transactionid=@TransactionId";
        var res=context.Execute(cmd,new {TransactionId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Transaction> GetTransactionById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Transactions where Transactionid=@TransactionId";
        var res=context.Query<Transaction>(cmd,new {TransactionId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Transaction>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<Transaction>(res);
    }

    public Response<List<Transaction>> GetTransactions()
    {
        using var context=_context.Connection();
        string cmd="select * from Transactions";
        var res=context.Query<Transaction>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Transaction>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Transaction>>(res);
    }

    public Response<bool> UpdateTransaction(Transaction Transaction)
    {
        using var context=_context.Connection();
        string cmd="update  Transactions set transactionid=@TransactionId ,fromaccountid=@FromAccountId,tomaccountid=@TomAccountId,issueddate=@IssuedDate,amount=@Amount,transactionmedium=@TransactionMedium,created_at=@Created_at,deleted_at=@Deleted_at";
        var res=context.Execute(cmd,Transaction);
        if(Transaction==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }
}


