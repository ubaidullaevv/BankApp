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
public class BranchController(IBranchService BranchService):ControllerBase
{
    [HttpGet]
    public Response<List<Branch>> GetResponses()
    {
        var response=BranchService.GetBranchs();
        return response;
    }
    [HttpPost]
    public Response<bool> AddBranch(Branch branch)
    {
        var response=BranchService.AddBranch(branch);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Branch branch)
    {
        var response=BranchService.UpdateBranch(branch);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=BranchService.DeleteBranch(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Branch> GetById(int id)
    {
        var response=BranchService.GetBranchById(id);
        return response;
    }
}
