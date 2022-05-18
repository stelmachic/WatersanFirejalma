using System.Drawing;


namespace Watersan_e_Firejalma
{
    public class CharacterHitBox : HitBox
    {
        public CharacterHitBox(Character character)
            => this.Character = character;
        public Character Character {get;}

        public override PointF[] Points
        {
            get => new PointF[]
            {
                new PointF(Character.posX + Character.width / 2, Character.posY),
                new PointF(Character.posX + Character.width / 2 + Character.width, Character.posY),
                new PointF(Character.posX + Character.width / 2 + Character.width, Character.posY + Character.height),
                new PointF(Character.posX + Character.width / 2, Character.posY + Character.height),
                new PointF(Character.posX + Character.width / 2, Character.posY)
            };
           
        }
    }
}


