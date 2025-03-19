using Kobyla.commands;

namespace Kobyla.units;

public class Horse(Game game)
{
    private int _fear = 0;
    public int Fear
    {
        get => _fear;
        set => _fear = int.Clamp(value, 0, 100);
    }

    private int iterations;
    public void Update()
    {
        iterations += 1;
        if (iterations%10==0) Fear--; //Decrease fear over time

        if (Fear == 100)
        {
            Game.GameOver("The horse spooked and ran off without you");
        }
    }

    public override string ToString()
    {
        return $"Horse Stats: Fear: {Fear}";
    }
}