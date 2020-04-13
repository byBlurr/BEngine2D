﻿using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
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
        public Vector2 position, positionGoto, velocity;
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
            this.positionGoto = startPos;
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

            this.position += (velocity * (float)delta);

            if (positionGoto.Y - this.position.Y >= 1.0f) velocity.Y = Math.Min(20.0f, (positionGoto.Y - this.position.Y));
            else if (this.position.Y - positionGoto.Y >= 1.0f) velocity.Y = Math.Max(-20.0f, -(this.position.Y - positionGoto.Y));
            else velocity.Y = 0.0f;

            if (positionGoto.X - this.position.X >= 1.0f) velocity.X = Math.Min(20.0f, (positionGoto.X - this.position.X));
            else if (this.position.X - positionGoto.X >= 1.0f) velocity.X = Math.Max(-20.0f, -(this.position.X - positionGoto.X));
            else velocity.X = 0.0f;

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

        public void MoveToPosition(System.Numerics.Vector2 position) => positionGoto = position;
    }
}
