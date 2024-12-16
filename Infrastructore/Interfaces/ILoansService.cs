using Domain.Models;
using Npgsql;
using Infrastructore.Response;
namespace Infrastructore.Interfaces;

public interface ILoanService
{
    public Response<List<Loan>> GetLoans();
    public Response<bool> AddLoan(Loan loan);
    public Response<bool> DeleteLoan(int id);
    public Response<bool> UpdateLoan(Loan loan);
    public Response<Loan> GetLoanById(int id);
    public Response<bool> AmountLimit(Loan loan);
}