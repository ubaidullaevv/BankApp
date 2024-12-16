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
    public async Task<Response<List<Branch>>> GetResponses()
    {
        var response=BranchService.GetBranches();
        return await response;
    }
    [HttpPost]
    public async Task<Response<bool>> AddBranch(Branch branch)
    {
        var response=BranchService.AddBranch(branch);
        return await response;
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Branch branch)
    {
        var response=BranchService.UpdateBranch(branch);
        return await response;
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        var response=BranchService.DeleteBranch(id);
        return await response;
    }
    [HttpGet ("get-by-id")]
    public async Task<Response<Branch>> GetById(int id)
    {
        var response=BranchService.GetBranchById(id);
        return await response;
    }
}
