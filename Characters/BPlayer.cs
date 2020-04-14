using BEngine2D.Entities;
using BEngine2D.Render;
using System;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.Characters
{
    public class BPlayer : BEntity
    {
        private BMovementType movementType;
        public Vector2 positionGoto, velocity;
        private float speed;
        private BState state;
        private RectangleF[] idleSprites, rSprites, ruSprites, rdSprites, lSprites, luSprites, ldSprites, uSprites, dSprites;
        float spriteId;

        public BPlayer(Vector2 startPos, BTexture spriteSheet, BMovementType movementType = BMovementType.MoveToPosition) : base(startPos, spriteSheet)
        {
            this.movementType = movementType;

            positionGoto = startPos;
            velocity = Vector2.Zero;
            speed = 20.0f;
            size = new Vector2(32, 32);
            state = BState.Idle;

            InitialiseSprites();
        }

        public void InitialiseSprites()
        {
            var spriteWidth = spriteSheet.Width / 6f;
            var spriteHeight = spriteSheet.Height / 9f;
            idleSprites = new RectangleF[]
            {
                new RectangleF(0, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, 0, spriteWidth, spriteHeight),
            };
            uSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight, spriteWidth, spriteHeight),
            };
            ruSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*2, spriteWidth, spriteHeight),
            };

            rSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*3, spriteWidth, spriteHeight),
            };
            rdSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*4, spriteWidth, spriteHeight),
            };
            dSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*5, spriteWidth, spriteHeight),
            };
            ldSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*6, spriteWidth, spriteHeight),
            };
            lSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*7, spriteWidth, spriteHeight),
            };
            luSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*8, spriteWidth, spriteHeight),
            };

            spriteId = 0.0f;
            currentSprite = idleSprites[0];
        }

        public override void Update(double delta)
        {
            base.Update(delta);
            HandleInput();
            HandleMovement(delta);
            ResolveCollision();
            UpdateSprite();
        }

        public void HandleInput()
        {
        }

        public void HandleMovement(double delta)
        {
            if (movementType == BMovementType.MoveToPosition)
            {
                if (positionGoto.Y - this.position.Y >= 0.1f) velocity.Y = Math.Min(speed, (positionGoto.Y - this.position.Y));
                else if (this.position.Y - positionGoto.Y >= 0.1f) velocity.Y = Math.Max(-speed, -(this.position.Y - positionGoto.Y));
                else velocity.Y = 0.0f;

                if (positionGoto.X - this.position.X >= 0.1f) velocity.X = Math.Min(speed, (positionGoto.X - this.position.X));
                else if (this.position.X - positionGoto.X >= 0.1f) velocity.X = Math.Max(-speed, -(this.position.X - positionGoto.X));
                else velocity.X = 0.0f;
            }

            if (velocity == Vector2.Zero) state = BState.Idle;
            if (velocity.X > 0.00f) state = BState.MovingR;
            if (velocity.X < 0.00f) state = BState.MovingL;

            this.position += (velocity * (float)delta);
        }

        public void ResolveCollision()
        {

        }

        public void UpdateSprite()
        {
            switch (state)
            {
                case BState.Idle:
                    currentSprite = idleSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingR:
                    currentSprite = rSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingRU:
                    currentSprite = ruSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingRD:
                    currentSprite = rdSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingL:
                    currentSprite = lSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingLU:
                    currentSprite = luSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingLD:
                    currentSprite = ldSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingU:
                    currentSprite = uSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BState.MovingD:
                    currentSprite = dSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                default:
                    currentSprite = idleSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
            }
        }

        public override void Draw()
        {
            base.Draw();

            if (state != BState.Idle)
            {
                if (velocity.X > 0.0f) spriteId += (float)velocity.X / 30f;
                else if (velocity.X < 0.0f) spriteId += -((float)velocity.X) / 30f;

                if (spriteId > 5.0f || spriteId < 0.0f) spriteId = 0f;
            }
        }

        public void MoveToPosition(System.Numerics.Vector2 position) => positionGoto = position;
        public void MoveInDirection(System.Numerics.Vector2 direction) => velocity = direction;
    }
}
