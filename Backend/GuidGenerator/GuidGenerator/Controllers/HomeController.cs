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

    [HttpPost("{topic}/{title}/{content}")]
    public async Task<IActionResult> Create(string topic = "default", string title = "Super Title!", string content = "This is a content of some fancy message! :D")
    {
        var db = _multiplexer.GetDatabase();

        var entity = new MessageEntity()
        {
            Content = content,
            Topic = topic,
            Title = title,
            CreatedTime = DateTime.Now
        };
        
        // Serialize the entity into JSON
        var json = JsonConvert.SerializeObject(entity);

        // Generate a unique key for the entity
        var key = Guid.NewGuid().ToString();

        var partitionKey = $"{entity.Topic}:{entity.CreatedTime.Minute}";

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