using Domain.Models;
using Npgsql;
using Infrastructore.Response;
namespace Infrastructore.Interfaces;

public interface ICustomerService
{
    public Response<List<Customer>> GetCustomers();
    public Response<bool> AddCustomer(Customer customer);
    public Response<bool> DeleteCustomer(int id);
    public Response<bool> UpdateCustomer(Customer customer);
    public Response<Customer> GetCustomerById(int id);
    public Response<bool> CheckAge(Customer customer);
    public Response<List<Customer>> GetCustomersByCity(string city);
}