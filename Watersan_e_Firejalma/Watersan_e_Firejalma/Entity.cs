using System.Drawing;


namespace Watersan_e_Firejalma
{
    public abstract class Entity
    {
        public HitBox HitBox { get; set; }

        public PointF Location { get; set; }

        public Entity(HitBox hitbox)
            => this.HitBox = hitbox;

        public virtual void DrawHitBox(Graphics g)
            => HitBox.Draw(g);

        public void CheckCollision(Entity entity, Graphics g)
        {
            var info = HitBox.IsColliding(entity.HitBox);
            if (info.IsColliding)
                OnCollision(info, g);
        }

        public virtual void OnCollision(CollisionInfo info, Graphics g) 
        {
        }

        public virtual void OnFrame() { }

        public abstract void Draw(Graphics g);
    }
}
