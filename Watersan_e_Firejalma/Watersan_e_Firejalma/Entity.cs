using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watersan_e_Firejalma
{
    public abstract class Entity
    {
        public HitBox HitBox { get; set; }
        public abstract void Draw(Graphics g);
        public virtual void DrawHitBox(Graphics g)
        {
            HitBox.Draw(g);
        }

        public virtual void CheckCollission(Entity entity)
        {
            if (this.HitBox.IsColliding(entity.HitBox))
            {
                OnCollision(entity);
                entity.OnCollision(this);
            }
        }

        public virtual void OnCollision(Entity entity) { }
    }
}
