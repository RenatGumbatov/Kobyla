using Kobyla.area;
using Kobyla.cells;
using Kobyla.commands;
using Kobyla.inventory;

namespace Kobyla.units;

public class Horse(Game game)
{
    private bool _standing = true;
    
    private int _fear;
    private int _stress;
    private int _health = 100;
    private int _framesPerStep;
    private int _stepsPerTurn = 30;
    private int _control = 100;

    public Direction Direction = Direction.Right;
    public Direction TurnDirection = Direction.Left;
    public int Fear { get => _fear; set => _fear = int.Clamp(value, 0, 100); }
    public int Stress { get => _stress; set => _stress = int.Clamp(value, 0, 100); }
    public int FramesPerStep { get => _framesPerStep; set => _framesPerStep = int.Clamp(value, 1, 30); }
    public int StepsPerTurn { get => _stepsPerTurn; set => _stepsPerTurn = int.Clamp(value, 1, 30); }
    public int Control { get => _control; set => _control = int.Clamp(value, 0, 100); }
    public int Health { get => _health; set => _health = int.Clamp(value, 0, 100); }
    
    private int _steps;
    public void Update()
    {
        // Decrease fear over time
        if (game.Frame%10==0) Fear--;

        // Decrease stress over time
        if (game.Frame%20==0) Stress--;

        // Damage horse with stress (?????)
        if (game.Frame%10==0 && Stress >= 95) Health--;

        if (StepsPerTurn <= 1)
        {
            Direction = GetTurnDirection(TurnDirection, Direction);
            StepsPerTurn = 30;
        }
        var framesPerStep = 0;
        var stepsPerTurn = StepsPerTurn;
        double multiplier = 2;
        if (Direction is Direction.Left or Direction.Right)
        {
            framesPerStep = FramesPerStep;
        }
        if (Direction is Direction.Up or Direction.Down)
        {
            framesPerStep = (int)(FramesPerStep*multiplier);
        }
        
        MoveAndTurn(framesPerStep, stepsPerTurn);
        
        // Fear check
        if (Fear == 100)
        {
            game.GameOver("The horse spooked and ran off without you");
        }
    }

    private void MoveAndTurn(int framesPerStep, int stepsPerTurn)
    {
        if (_standing) return;
        //Move
        if (game.Frame % framesPerStep == 0)
        {
            var newPosition = game.Player.Position.moveToDirection(Direction);
            //Turn
            if (_steps%stepsPerTurn == 0)
            {
                newPosition = newPosition.moveToDirection(GetTurnDirection(TurnDirection, Direction));
                _steps = 0;
            }
            //Update position
            _steps++;
            UpdateDescend(game.Player.Position, newPosition);
            game.Player.TeleportTo(newPosition);
            
            // Random Item find
            Random random = new Random();
            if (random.Next(0, 1000) == 0)
            {
                game.ConsoleUI.Messages.AddMessage(new Message("Found 1 Apple!"));
                game.Player.Inventory.AddItem(new Apple(game));
            }
        }
    }

    private void UpdateDescend(Point from, Point to)
    {
        if (game.Frame % 100 == 0) Control++;
        if (Control <= 0) game.GameOver("You fell from the horse whilst galloping.");
        if (!isDescend(from, to)) return;
        Control -= 10;
    }
    private bool isDescend(Point from, Point to)
    {
        if (from.X < 0 || from.Y < 0 || to.X < 0 || to.Y < 0) return false;
        if (from.X >= game.CurrentMap.Width || from.Y >= game.CurrentMap.Height) return false;
        if (to.X >= game.CurrentMap.Width || to.Y >= game.CurrentMap.Height) return false;
        var fromCell = game.CurrentMap.Cells[from.X, from.Y];
        var toCell = game.CurrentMap.Cells[to.X, to.Y];
        if (!(fromCell is Terrain && toCell is Terrain)) return false;
        var fromTerrain = fromCell as Terrain;
        var toTerrain = toCell as Terrain;
        return toTerrain != null && fromTerrain != null && fromTerrain.Height > toTerrain.Height;
    }

    private Direction GetTurnDirection(Direction turnDirection, Direction moveDirection)
    {
        switch (turnDirection)
        {
            case Direction.Right:
                return DirectionExtensions.GetRightDirection(moveDirection);
            case Direction.Left:
                return DirectionExtensions.GetLeftDirection(moveDirection);
            default:
                throw new Exception("Invalid turn direction");
        }
    }

    private void SuggestDirection(Direction direction, int force, int turnForce)
    {
        StepsPerTurn-=force;
        if (direction == Direction.None)
        {
            StepsPerTurn = 30;
            return;
        }
        TurnDirection = direction;
        StepsPerTurn -= turnForce;
    }

    private void IncreaseSpeed(int amount)
    {
        FramesPerStep -= amount;
        FramesPerStep = Math.Max(1, FramesPerStep);
    }

    public void Spur(Direction direction)
    {
        Stress += 5;
        if (_standing)
        {
            _standing = false;
            FramesPerStep = (int)Speed.Walk;
        }
        IncreaseSpeed(5);
        SuggestDirection(direction, 5, 10);
    }

    public void PullReigns(Direction direction)
    {
        var turnForce = 4;
        Stress += 2;
        if (direction == Direction.None)
        {
            _standing = true;
            FramesPerStep = 30;
            StepsPerTurn = 30;
            return;
        }
        TurnDirection = direction;
        StepsPerTurn -= turnForce;
    }

    public void ReleaseReigns()
    {
        Stress -= 2;
        StepsPerTurn = 30;
    }

    public override string ToString()
    {
        return $"Horse Stats: Health: {Health}, Fear: {Fear}, Stress: {Stress}, Direction: {Direction}, TurnDirection: {TurnDirection}, FramesPerStep {FramesPerStep}, StepsPerTurn: {StepsPerTurn}, Control: {Control}";
    }
}