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
    public async Task<Response<List<Customer>>> GetResponses()
    {
        var response=customerService.GetCustomers();
        return await response;
    }
    [HttpPost]
    public async Task<Response<bool>> AddCustomer(Customer Customer)
    {
        var response=customerService.AddCustomer(Customer);
        return await response;
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Customer Customer)
    {
        var response=customerService.UpdateCustomer(Customer);
        return await response;
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        var response=customerService.DeleteCustomer(id);
        return await response;
    }
    [HttpGet ("get-by-id")]
    public async Task<Response<Customer>> GetById(int id)
    {
        var response=customerService.GetCustomerById(id);
        return await response;
    }
    [HttpPost("ckeck-age")]
    public async Task<Response<bool>> CheckAge(Customer customer)
    {
        var response=customerService.CheckAge(customer);
        return await response;
    }

        [HttpGet("get-by-city")]
    public async Task<Response<List<Customer>>> GetCustomersByCity(string city)
    {
        var response=customerService.GetCustomersByCity(city);
        return await response;
    }
}
