using System.Drawing;


namespace Watersan_e_Firejalma
{
    public class CharacterHitBox : HitBox
    {
        int tolerance = 5;
        public CharacterHitBox(Character character)
            => this.Character = character;
        public Character Character {get;}

        public override PointF[] Points
        {
            get => new PointF[]
            {
                new PointF(Character.posX + Character.width / 2 + tolerance, Character.posY + tolerance),
                new PointF(Character.posX + Character.width / 2 + Character.width - tolerance, Character.posY + tolerance),
                new PointF(Character.posX + Character.width / 2 + Character.width - tolerance, Character.posY + Character.height ),
                new PointF(Character.posX + Character.width / 2 + tolerance, Character.posY + Character.height),
                new PointF(Character.posX + Character.width / 2 + tolerance, Character.posY + tolerance)
            };
           
        }
    }
}


