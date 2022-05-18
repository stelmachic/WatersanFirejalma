using System.Collections.Generic;

namespace Watersan_e_Firejalma
{
    public class CollisionManager
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public void HandleCollisions()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                for (int j = i + 1; j < Entities.Count; j++)
                {
                    Entities[i].CheckCollision(Entities[j]);
                }
            }
        }
    }
}