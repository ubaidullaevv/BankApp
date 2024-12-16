using Domain.Models;
using Npgsql;
using Infrastructore.Response;
namespace Infrastructore.Interfaces;

public interface IBranchService
{
    public Response<List<Branch>> GetBranchs();
    public Response<bool> AddBranch(Branch branch);
    public Response<bool> DeleteBranch(int id);
    public Response<bool> UpdateBranch(Branch branch);
    public Response<Branch> GetBranchById(int id);
}