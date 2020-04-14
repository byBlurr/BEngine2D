using BEngine2D.Render;
using System;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.Characters
{
    public class BPlayer
    {
        private BMovementType movementType;
        public Vector2 position, positionGoto, velocity;
        private float speed;
        private Vector2 size;

        private BTexture2D playerSprite;
        private bool facingRight, facingLeft, facingUp, facingDown, sprinting;
        private RectangleF[] idleTextures, rightTextures, leftTextures, upTextures, downTextures;

        public RectangleF ColRec
        {
            get
            {
                return new RectangleF(position.X - size.X / 2f, position.Y - size.Y / 2f, size.X, size.Y);
            }
        }

        public RectangleF DrawRec
        {
            get
            {
                RectangleF colRec = ColRec;
                colRec.X = colRec.X - 5;
                colRec.Width = colRec.Width + 10;
                return colRec;
            }
        }

        public BPlayer(Vector2 startPos, BMovementType movementType = BMovementType.MoveToPosition)
        {
            this.position = startPos;
            this.positionGoto = startPos;
            this.velocity = Vector2.Zero;
            this.speed = 20.0f;
            this.movementType = movementType;
            facingRight = false;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            sprinting = false;
            this.size = new Vector2(32, 32);
            this.playerSprite = BContentPipe.LoadTexture("Characters/player.png");

            var spriteWidth = playerSprite.Width / 6f;
            var spriteHeight = playerSprite.Height / 6f;
            idleTextures = new RectangleF[]
            {
                new RectangleF(0, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, 0, spriteWidth, spriteHeight),
            };
        }

        public void Update(double delta)
        {
            HandleInput();

            if (movementType == BMovementType.MoveToPosition)
            {
                if (positionGoto.Y - this.position.Y >= 1.0f) velocity.Y = Math.Min(speed, (positionGoto.Y - this.position.Y));
                else if (this.position.Y - positionGoto.Y >= 1.0f) velocity.Y = Math.Max(-speed, -(this.position.Y - positionGoto.Y));
                else velocity.Y = 0.0f;

                if (positionGoto.X - this.position.X >= 1.0f) velocity.X = Math.Min(speed, (positionGoto.X - this.position.X));
                else if (this.position.X - positionGoto.X >= 1.0f) velocity.X = Math.Max(-speed, -(this.position.X - positionGoto.X));
                else velocity.X = 0.0f;
            }

            this.position += (velocity * (float)delta);

            ResolveCollision();
        }

        public void HandleInput()
        {
        }

        public void ResolveCollision()
        {

        }
        
        public void Draw()
        {
            RectangleF texture = idleTextures[0];

            BGraphics.Draw(
                playerSprite,
                this.position,
                new Vector2(DrawRec.Width / playerSprite.Width *2, DrawRec.Height / playerSprite.Height *2),
                Color.Transparent,
                new Vector2(DrawRec.Width / 2f, (DrawRec.Height / 4)*3),
                //new RectangleF(0, 0, playerSprite.Width / 6f, playerSprite.Height / 6f)
                texture
            );
        }

        public void MoveToPosition(System.Numerics.Vector2 position) => positionGoto = position;
        public void MoveInDirection(System.Numerics.Vector2 direction) => velocity = direction;
    }
}
