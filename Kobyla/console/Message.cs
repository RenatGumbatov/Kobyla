namespace Kobyla.commands;

public class Message
{
    private readonly string _text;
    private bool _countdownStarted = false;
    public bool IsAlive = true;
    private int FramesOnStart;
    public int FramesLeft;

    public Message(string text, int framesLeft)
    {
        _text = text;
        FramesLeft = framesLeft;
        FramesOnStart = framesLeft;
    }

    public void Update()
    {
        if (!_countdownStarted) return;
        if (FramesLeft > 0)
        {
            FramesLeft--;
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
        return loadingBar(10) + " " + _text;
    }

    private String loadingBar(int length)
    {
        if (length < 3) return "";
        
        string output = "[";
        length -= 2;
        int framesLeft = (int)((double)FramesLeft / (double)FramesOnStart * (double)length);
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