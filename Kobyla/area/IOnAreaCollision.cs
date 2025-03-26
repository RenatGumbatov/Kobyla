using Kobyla.area;
using Kobyla.units;

namespace Kobyla;

public interface IOnAreaCollision
{
    void OnAreaCollision(Area area, List<Unit> unitsCollidedWith);
    void CheckCollision();
}