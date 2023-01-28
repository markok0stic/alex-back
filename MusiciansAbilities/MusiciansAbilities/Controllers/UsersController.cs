using Microsoft.AspNetCore.Mvc;
using MusiciansAbilities.Models;
using MusiciansAbilities.Services;

namespace MusiciansAbilities.Controllers;

public class UsersController: Controller
{
    private readonly IDbService _dbService;
    
    public UsersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody]User user) 
    {
        try
        {
            if (!await _dbService.InsertUser(user))
                return BadRequest();
            return Ok();
        }
        catch(Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpPost] 
    public async Task<IActionResult> AddExperimentResult([FromBody]List<ExperimentResult> result, string userId) 
    {
        try
        {
            if (!await _dbService.InsertExperimentResultsForUser(result, userId))
                return BadRequest("User not found!");
            return Ok();
        }
        catch(Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await _dbService.GetUsers());
        }
        catch(Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUser(string userId)
    {
        try
        {
            return Ok(await _dbService.GetUsers(userId));
        }
        catch(Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }
}