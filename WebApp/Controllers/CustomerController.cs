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
public class CustomerController(ICustomerService customerService):ControllerBase
{
    [HttpGet]
    public Response<List<Customer>> GetResponses()
    {
        var response=customerService.GetCustomers();
        return response;
    }
    [HttpPost]
    public Response<bool> AddCustomer(Customer Customer)
    {
        var response=customerService.AddCustomer(Customer);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Customer Customer)
    {
        var response=customerService.UpdateCustomer(Customer);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=customerService.DeleteCustomer(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Customer> GetById(int id)
    {
        var response=customerService.GetCustomerById(id);
        return response;
    }
    [HttpPost("ckeck-age")]
    public Response<bool> CheckAge(Customer customer)
    {
        var response=customerService.CheckAge(customer);
        return response;
    }

        [HttpGet("get-by-city")]
    public Response<List<Customer>> GetCustomersByCity(string city)
    {
        var response=customerService.GetCustomersByCity(city);
        return response;
    }
}
