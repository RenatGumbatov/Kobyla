namespace Kobyla.commands;

public class Message
{
    private readonly string _text;
    private bool _countdownStarted = false;
    private readonly bool _showLoadingBar = true;
    public bool IsAlive = true;
    private readonly int _framesOnStart;
    private const int StandartFramesLength = 100;
    private int _framesLeft;

    public Message(string text, int framesLeft)
    {
        _text = text;
        _framesLeft = framesLeft;
        _framesOnStart = framesLeft;
    }
    public Message(string text, int framesLeft, bool showLoadingBar)
    {
        _text = text;
        _framesLeft = framesLeft;
        _framesOnStart = framesLeft;
        _showLoadingBar = showLoadingBar;
    }

    public Message(string text)
    {
        _text = text;
        _framesLeft = StandartFramesLength;
        _framesOnStart = StandartFramesLength;
        _showLoadingBar = true;
    }

    public void Update()
    {
        if (!_countdownStarted) return;
        if (_framesLeft > 0)
        {
            _framesLeft--;
        }
        else
        {
            IsAlive = false;
        }
    }
    public void StartCountdown()
    {
        _countdownStarted = true;
    }

    public override string ToString()
    {
        if (_showLoadingBar) return loadingBar(10) + " " + _text;
        return _text;
    }

    private String loadingBar(int length)
    {
        if (length < 3) return "";
        
        string output = "[";
        length -= 2;
        int framesLeft = (int)((double)_framesLeft / (double)_framesOnStart * (double)length);
        for (int i = 0; i < framesLeft; i++)
        {
            output += "#";
        }
        for (int i = 0; i < length-framesLeft; i++)
        {
            output += "-";
        }
        output += "]";
        return output;
    }
}