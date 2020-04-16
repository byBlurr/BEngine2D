﻿using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using System;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.Entities
{
    /// <summary>
    /// Derived from BEntity. Adds characteristics to the entity.
    /// </summary>
    public class BCharacter : BEntity
    {
        // Movement
        private BMovementType movementType;
        public Vector2 positionGoto, velocity;

        // States
        private BEntityState currentState;

        // Statistics
        private float maxMovementSpeed;
        private int maxHealth;
        private int currentHealth;

        public BCharacter(Vector2 position, BTexture spriteSheet) : base(position, spriteSheet)
        {
            movementType = BMovementType.MoveToPosition;
            positionGoto = position;
            velocity = Vector2.Zero;
            currentState = BEntityState.Idle;
            maxMovementSpeed = 20.0f;
            maxHealth = 200;
            currentHealth = maxHealth;
        }
        public BCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox) : base(position, spriteSheet, spriteBox)
        {
            movementType = BMovementType.MoveToPosition;
            positionGoto = position;
            velocity = Vector2.Zero;
            currentState = BEntityState.Idle;
            maxMovementSpeed = 20.0f;
            maxHealth = 200;
            currentHealth = maxHealth;
        }
        public BCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox, BMovementType movementType) : base(position, spriteSheet, spriteBox)
        {
            this.movementType = movementType;
            positionGoto = position;
            velocity = Vector2.Zero;
            currentState = BEntityState.Idle;
            maxMovementSpeed = 20.0f;
            maxHealth = 200;
            currentHealth = maxHealth;
        }
        public BCharacter(Vector2 position, BTexture spriteSheet, RectangleF spriteBox, BMovementType movementType, float maxMovementSpeed, int maxHealth) : base(position, spriteSheet, spriteBox)
        {
            this.movementType = movementType;
            this.maxMovementSpeed = maxMovementSpeed;
            this.maxHealth = maxHealth;

            positionGoto = position;
            velocity = Vector2.Zero;
            currentState = BEntityState.Idle;
            currentHealth = maxHealth;
        }

        public override void Update(double delta, BLevel level)
        {
            base.Update(delta, level);

            HandleMovement(delta);
            HandleCollision(level);
        }

        public void HandleMovement(double delta)
        {
            if (movementType == BMovementType.MoveToPosition)
            {
                if (positionGoto.Y - this.position.Y >= 0.1f) velocity.Y = Math.Min(maxMovementSpeed, (positionGoto.Y - this.position.Y));
                else if (this.position.Y - positionGoto.Y >= 0.1f) velocity.Y = Math.Max(-maxMovementSpeed, -(this.position.Y - positionGoto.Y));
                else velocity.Y = 0.0f;

                if (positionGoto.X - this.position.X >= 0.1f) velocity.X = Math.Min(maxMovementSpeed, (positionGoto.X - this.position.X));
                else if (this.position.X - positionGoto.X >= 0.1f) velocity.X = Math.Max(-maxMovementSpeed, -(this.position.X - positionGoto.X));
                else velocity.X = 0.0f;
            }

            if (velocity == Vector2.Zero) currentState = BEntityState.Idle;
            if (velocity.X > 0.00f) currentState = BEntityState.MovingR;
            if (velocity.X < 0.00f) currentState = BEntityState.MovingL;

            this.position += (velocity * (float)delta);
        }

        public void HandleCollision(BLevel level)
        {
            int minX = (int)(Math.Floor((this.position.X - size.X / 2f) / AppInfo.GRIDSIZE));
            int minY = (int)(Math.Floor((this.position.Y - size.Y / 2f) / AppInfo.GRIDSIZE));
            int maxX = (int)(Math.Floor((this.position.X + size.X / 2f) / AppInfo.GRIDSIZE));
            int maxY = (int)(Math.Floor((this.position.Y + size.Y / 2f) / AppInfo.GRIDSIZE));
            RectangleF thisCollide = new RectangleF(position.X + CollisionBox.X, position.Y + CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    RectangleF blockRec = new RectangleF(x * AppInfo.GRIDSIZE, y * AppInfo.GRIDSIZE, AppInfo.GRIDSIZE, AppInfo.GRIDSIZE);

                    if (level[x, y].IsSolid && thisCollide.IntersectsWith(blockRec))
                    {
                        #region Resolve Collision

                        float[] depths = new float[4]
                        {
                            blockRec.Right - thisCollide.Left, // Pos X
                            blockRec.Bottom - thisCollide.Top, // Pos Y
                            thisCollide.Right - blockRec.Left, // Neg X
                            thisCollide.Bottom - blockRec.Top, // Neg Y
                        };

                        Point[] directions = new Point[4]
                        {
                            new Point(1, 0),
                            new Point(0, 1),
                            new Point(-1, 0),
                            new Point(0, -1),
                        };

                        float min = float.MaxValue;
                        Vector2 minDirection = Vector2.Zero;

                        for (int i = 0; i < 4; i++)
                        {
                            if (!level[x + directions[i].X, y + directions[i].Y].IsSolid &&
                                depths[i] < min)
                            {
                                min = depths[i];
                                minDirection = new Vector2(directions[i].X, directions[i].Y);
                            }
                        }

                        if (min == float.MaxValue)
                            continue;

                        this.position += minDirection * min;

                        if (this.velocity.X * minDirection.X < 0) this.velocity.X = 0;
                        if (this.velocity.Y * minDirection.Y < 0) this.velocity.Y = 0;
                        #endregion
                    }
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void MoveToPosition(System.Numerics.Vector2 position) => positionGoto = position;
        public void MoveInDirection(System.Numerics.Vector2 direction) => velocity = direction;

        // Getters
        protected BMovementType MovementType { get => movementType; }
        protected BEntityState CurrentState { get => currentState; }
        protected float MaxMovementSpeed { get => maxMovementSpeed; }
        protected int MaxHealth { get => maxHealth; }
        protected int CurrentHealth { get => currentHealth; }
    }
}
