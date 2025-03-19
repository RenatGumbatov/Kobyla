namespace Kobyla.commands;

public class Message
{
    private readonly string _text;
    private long _time;
    public bool IsAlive = true;
    private Timer _timer;
    private bool _killOnRead;

    public Message(string text, long time, bool killOnRead = false)
    {
        _text = text;
        _time = time;
        _killOnRead = killOnRead;
    }

    public void StartCountdown()
    {
        _timer = new Timer(OnTimerEnd!, null, _time, Timeout.Infinite);
    }

    private void OnTimerEnd(object data)
    {
        IsAlive = false;
        _timer.Dispose();
    }

    public override string ToString()
    {
        if (_killOnRead) IsAlive = false;
        return _text;
    }
}