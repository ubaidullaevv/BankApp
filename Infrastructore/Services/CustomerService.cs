using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class CustomerService(DapperContext _context) : ICustomerService
{
   public Response<bool> AddCustomer(Customer customer)
    {
        using var context=_context.Connection();
        string cmd="insert into Customers(fullname,city,phone,cardnumber,dob,created_at,deleted_at)values(@FullName,@City,@Phone,@CardNumber,@DOB,@Created_at,@Deleted_at)";
        var res=context.Execute(cmd,customer);
        if(customer==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteCustomer(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Customers where customerid=@CustomerId";
        var res=context.Execute(cmd,new {CustomerId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Customer> GetCustomerById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Customers where customerid=@CustomerId";
        var res=context.Query<Customer>(cmd,new {CustomerId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Customer>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<Customer>(res);
    }

    public Response<List<Customer>> GetCustomers()
    {
        using var context=_context.Connection();
        string cmd="select * from Customers";
        var res=context.Query<Customer>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Customer>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Customer>>(res);
    }

    public Response<bool> UpdateCustomer(Customer customer)
    {
        using var context=_context.Connection();
        string cmd="update  Customers set customerid=@CustomerId ,fullname=@FullName,city=@City,phone=@Phone,cardnumber=@CardNumber,dob=@DOB,created_at=@Created_at,deleted_at=@Deleted_at";
        var res=context.Execute(cmd,customer);
        if(customer==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> CheckAge(Customer customer)
    {
     using var context=_context.Connection();
     string cmd=@"""insert into customers(fullname,city,phone,cardnumber,dob,created_at,deleted_at)
     values(@FullName,@City,@Phone,@CardNumber,@DOB,@Created_at,@Deleted_at)
     where dob>=2006-01-01 00:00:00 """;
     var res=context.Execute(cmd,customer);
     if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"You are Child for comming to bank!");
     return new Response<bool>(res>0);
    }

    public Response<List<Customer>> GetCustomersByCity(string city)
    {
        using var context=_context.Connection();
        string cmd="select * from customers where city=@City";
        var res=context.Query<Customer>(cmd,new {City=city}).ToList();
        if(res==null) return new Response<List<Customer>>(HttpStatusCode.NotFound,"No customers in this city");
        return new Response<List<Customer>>(res);
    }
}


