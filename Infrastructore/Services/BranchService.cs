using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class BranchService(DapperContext _context) : IBranchService
{
   public Response<bool> AddBranch(Branch branch)
    {
        using var context=_context.Connection();
        string cmd="insert into Branches(name,location,phone,created_at,deleted_at)values(@Name,@Location,@Phone,@Created_at,@Deleted_at)";
        var res=context.Execute(cmd,branch);
        if(branch==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteBranch(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Branches where Branchid=@BranchId";
        var res=context.Execute(cmd,new {BranchId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Branch> GetBranchById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Branches where Branchid=@BranchId";
        var res=context.Query<Branch>(cmd,new {BranchId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Branch>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<Branch>(res);
    }

    public Response<List<Branch>> GetBranchs()
    {
        using var context=_context.Connection();
        string cmd="select * from Branches";
        var res=context.Query<Branch>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Branch>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Branch>>(res);
    }

    public Response<bool> UpdateBranch(Branch branch)
    {
        using var context=_context.Connection();
        string cmd="update  Branches set branchid=@BranchId ,name=@Name,location=@Location,phone=@Phone,created_at=@Created_at,deleted_at=@Deleted_at";
        var res=context.Execute(cmd,branch);
        if(branch==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }
}


