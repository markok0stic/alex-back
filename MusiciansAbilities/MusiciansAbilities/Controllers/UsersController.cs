using Microsoft.AspNetCore.Mvc;
using MusiciansAbilities.Models;
using MusiciansAbilities.Services;

namespace MusiciansAbilities.Controllers;

public class UsersController: Controller
{
    private readonly IDbService _dbService;
    private readonly ILogger<UsersController> _logger;
    public UsersController(IDbService dbService, ILogger<UsersController> logger)
    {
        _dbService = dbService;
        _logger = logger;
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
            _logger.LogError(e,"");
            return UnprocessableEntity(e.Message+e.StackTrace);
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
            _logger.LogError(e,"");
            return UnprocessableEntity(e.Message+e.StackTrace);
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
            _logger.LogError(e,"");
            return UnprocessableEntity(e.Message+e.StackTrace);
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
            _logger.LogError(e,"");
            return UnprocessableEntity(e.Message+e.StackTrace);
        }
    }
}