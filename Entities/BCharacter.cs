using BEngine2D.Render;
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

        public override void Update(double delta)
        {
            base.Update(delta);

            HandleMovement(delta);
            ResolveCollision();
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

        public void ResolveCollision()
        {

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
