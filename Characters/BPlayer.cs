using BEngine2D.Input;
using BEngine2D.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Entity
{
    public class BPlayer
    {
        public Vector2 position, velocity;
        private float speed, acceleration;
        private Vector2 size;

        private BTexture2D playerSprite;
        private bool facingRight, facingLeft, facingUp, facingDown, sprinting;

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

        public BPlayer(Vector2 startPos)
        {
            this.position = startPos;
            this.velocity = Vector2.Zero;
            this.speed = 10.0f;
            this.acceleration = 0.2f;
            facingRight = false;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            sprinting = false;
            this.size = new Vector2(20, 40);
            this.playerSprite = BContentPipe.LoadTexture("Characters/player.png");
        }

        public void Update(double delta)
        {
            HandleInput();

            this.position += (velocity * (float) delta);
            ResolveCollision();
        }

        public void HandleInput()
        {
            if (BKeyboardListener.IsKeyPressed(BKey.W))
            {
                facingUp = true;
            }
            else facingUp = false;
            if (BKeyboardListener.IsKeyPressed(BKey.S))
            {
                facingDown = true;
            }
            else facingDown = false;

            if (facingUp && !facingDown)
            {
                velocity.Y -= speed / acceleration;
                if (velocity.Y < -speed) velocity.Y = -speed;
            } 
            else if (!facingUp && facingDown)
            {
                velocity.Y += speed / acceleration;
                if (velocity.Y > speed) velocity.Y = speed;
            }
            else if (!facingUp && !facingDown)
            {
                velocity.Y = 0;
            }
            else if (facingUp && facingDown)
            {
                velocity.Y = 0;
            }

            if (BKeyboardListener.IsKeyPressed(BKey.D))
            {
                facingRight = true;
            }
            else facingRight = false;
            if (BKeyboardListener.IsKeyPressed(BKey.A))
            {
                facingLeft = true;
            }
            else facingLeft = false;

            if (facingRight && !facingLeft)
            {
                velocity.X += speed / acceleration;
                if (velocity.X > speed) velocity.X = speed;
            }
            else if (!facingRight && facingLeft)
            {
                velocity.X -= speed / acceleration;
                if (velocity.X < -speed) velocity.X = -speed;
            }
            else if (!facingRight && !facingLeft)
            {
                velocity.X = 0;
            }
            else if (facingRight && facingLeft)
            {
                velocity.X = 0;
            }
        }

        public void ResolveCollision()
        {

        }
        
        public void Draw()
        {
            // Draw the player!!
            BGraphics.Draw(
                playerSprite, 
                this.position, 
                new Vector2(DrawRec.Width / playerSprite.Width, DrawRec.Height / playerSprite.Height), 
                Color.Transparent,
                new Vector2(playerSprite.Width / 4f, playerSprite.Height / 2f),
                new RectangleF(0, 0, playerSprite.Width / 5f, playerSprite.Height/2)
            );
        }
    }
}
