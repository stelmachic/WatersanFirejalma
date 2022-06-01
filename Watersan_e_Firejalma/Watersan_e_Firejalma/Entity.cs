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

        public void CheckCollision(Block box, Graphics g)
        {
            var info = HitBox.IsColliding(box.HitBox);
            if (info.IsColliding)
                OnCollision(info, g, box.blockType);
        }

        public void CheckCollision(Asset asset, Graphics g)
        {
            var info = HitBox.IsColliding(asset.HitBox);
            if (info.IsColliding)
                OnCollision(info, g, asset.blockType);
        }

        public virtual void OnCollision(CollisionInfo info, Graphics g, int blockType) 
        {
     
        }

        public virtual void OnFrame() { }

        public abstract void Draw(Graphics g);
    }
}
