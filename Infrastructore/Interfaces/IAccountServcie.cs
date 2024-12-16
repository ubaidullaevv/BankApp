using Domain.Models;
using Npgsql;
using Infrastructore.Response;
namespace Infrastructore.Interfaces;

public interface IAccountService
{
    public Response<List<Account>> GetAccounts();
    public Response<bool> AddAccount(Account account);
    public Response<bool> DeleteAccount(int id);
    public Response<bool> UpdateAccount(Account account);
    public Response<Account> GetAccountById(int id);
    //public Response<bool> UpdateStatus(int id, string status);
}