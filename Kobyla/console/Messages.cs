namespace Kobyla.commands;

public class Messages
{
    private List<Message> _messages = [];

    public void AddMessage(Message message)
    {
        _messages.Add(message);
        message.StartCountdown();
    }

    public override string ToString()
    {
        DeleteDeadMessages();
        var output = "";
        foreach (var message in _messages)
        {
            output += $"{message}\n";
        }
        return output;
    }

    private void DeleteDeadMessages()
    {
        foreach (var message in _messages.ToList())
        {
            if (!message.IsAlive) _messages.Remove(message);
        }
    }
}