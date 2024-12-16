using Domain.Models;
using Npgsql;
using Infrastructore.Response;
namespace Infrastructore.Interfaces;

public interface ITransactionService
{
    public Response<List<Transaction>> GetTransactions();
    public Response<bool> AddTransaction(Transaction transaction);
    public Response<bool> DeleteTransaction(int id);
    public Response<bool> UpdateTransaction(Transaction transaction);
    public Response<Transaction> GetTransactionById(int id);
}