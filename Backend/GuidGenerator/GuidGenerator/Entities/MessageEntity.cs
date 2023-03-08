namespace GuidGenerator.Entities;

public class MessageEntity
{
    public string Sender { get; set; }
    public string Content { get; set; }
    public string ChatName { get; set; }
    public DateTime CreatedTime { get; set; }
}