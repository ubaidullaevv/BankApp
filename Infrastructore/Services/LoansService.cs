using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class LoanService(DapperContext _context) : ILoanService
{
   public Response<bool> AddLoan(Loan loan)
    {
        using var context=_context.Connection();
        string cmd="insert into Loans(customerid,branchid,amount,issueddate,created_at,deleted_at)values(@CustomerId,@BranchId,@Amount,@IssuedDate,@Created_at,@Deleted_at)";
        var res=context.Execute(cmd,loan);
        if(loan==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteLoan(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Loans where Loanid=@LoanId";
        var res=context.Execute(cmd,new {LoanId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Loan> GetLoanById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Loans where Loanid=@LoanId";
        var res=context.Query<Loan>(cmd,new {LoanId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Loan>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<Loan>(res);
    }

    public Response<List<Loan>> GetLoans()
    {
        using var context=_context.Connection();
        string cmd="select * from Loans";
        var res=context.Query<Loan>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Loan>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Loan>>(res);
    }

    public Response<bool> UpdateLoan(Loan loan)
    {
        using var context=_context.Connection();
        string cmd="update  Loans set Loanid=@LoanId ,customerid=@CustomerId,branchid=@BranchId,amount=@Amount,issueddate=@IssuedDate,created_at=@Creatd_at,deleted_at=@Deleted_at";
        var res=context.Execute(cmd,loan);
        if(loan==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }


    public Response<bool> AmountLimit(Loan loan)
    {
        using var context=_context.Connection();
        string cmd=@"""insert into Loans(customerid,branchid,amount,issueddate,created_at,deleted_at)
        values(@CustomerId,@BranchId,@Amount,@IssuedDate,@Created_at,@Deleted_at)
        where amount<=100000.00""";
        var res=context.Execute(cmd,loan);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Amount destroys limit!");
        return new Response<bool>(res>0);
    }
}


