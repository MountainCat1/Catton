using GuidGenerator.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace GuidGenerator.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IConnectionMultiplexer _multiplexer;

    public HomeController(IConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
    }

    [HttpGet(Name = "")]
    public async Task<IActionResult> Get()
    {
        var db = _multiplexer.GetDatabase();

        var entity = new MessageEntity()
        {
            Message = "Hellow! It's a message!",
            Title = "Super title",
            CreatedTime = DateTime.Now
        };
        
        // Serialize the entity into JSON
        var json = JsonConvert.SerializeObject(entity);

        // Generate a unique key for the entity
        var key = Guid.NewGuid().ToString();

        var partitionKey = entity.CreatedTime.Minute.ToString();

        var fullKey = $"{partitionKey}:{key}";
        
        // Add the entity to Redis
        await db.StringSetAsync(fullKey, json);

        // Retrieve the entity from Redis
        var resultJson = await db.StringGetAsync(fullKey);

        // Deserialize the entity from JSON
        var resultEntity = JsonConvert.DeserializeObject<MessageEntity>(resultJson);
        
        return Ok(resultEntity);
    }
}