using BEngine2D.Render;
using BEngine2D.World;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.Entities
{
    public class BPlayableCharacter : BCharacter
    {
        public BPlayableCharacter(Vector2 position, BTexture spriteSheet) : base(position, spriteSheet)
        {
        }
        public BPlayableCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox) : base(position, spriteSheet, spriteBox)
        {
        }
        public BPlayableCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox, BMovementType movementType) : base(position, spriteSheet, spriteBox, movementType)
        {
        }
        public BPlayableCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox, BMovementType movementType, float maxMovementSpeed, int maxHealth) : base(position, spriteSheet, spriteBox, movementType, maxMovementSpeed, maxHealth)
        {
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(double delta, BLevel level)
        {
            HandleInput();
            base.Update(delta, level);
        }

        public void HandleInput()
        {
        }
    }
}
