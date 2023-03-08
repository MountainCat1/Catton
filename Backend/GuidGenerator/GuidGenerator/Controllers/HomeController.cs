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

    [HttpPost("{name}")]
    public async Task<IActionResult> CreateChat(string name)
    {
        var db = _multiplexer.GetDatabase();

        var newEntity = new ChatEntity()
        {
            Name = name,
            TimeCreated = DateTime.Now
        };

        var json = JsonConvert.SerializeObject(newEntity);

        var partitionKey = "chat";
        
        var key = name;

        var fullKey = $"{partitionKey}:{key}";
        
        // Add the entity to Redis
        await db.StringSetAsync(fullKey, json);
        
        return Ok();
    }

    [HttpPost("{chatName}/{sender}/{content}")]
    public async Task<IActionResult> CreateMessages(string chatName, string sender, string content)
    {
        var db = _multiplexer.GetDatabase();

        // Check if chat exists
        var chatRedisValue = await db.StringGetAsync($"chat:{chatName}");

        if (chatRedisValue.IsNull)
            return NotFound();
        
        var entity = new MessageEntity()
        {
            Content = content,
            ChatName = chatName,
            Sender = sender,
            CreatedTime = DateTime.Now
        };
    
        // Serialize the entity into JSON
        var json = JsonConvert.SerializeObject(entity);

        // Add the entity to the chat room list in Redis
        var listKey = $"messages:{entity.ChatName}";
        await db.ListRightPushAsync(listKey, json);
    
        return Ok();
    }
    
    [HttpGet("{chatName}")]
    public async Task<IActionResult> GetChat(string chatName)
    {
        var db = _multiplexer.GetDatabase();
    
        var listKey = $"messages:{chatName}";
    
        var redisValues = await db.ListRangeAsync(listKey);
    
        var messages = redisValues
            .Select(x => JsonConvert.DeserializeObject<MessageEntity>(x.ToString()));

        return Ok(messages);
    }
}