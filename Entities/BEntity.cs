using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.Entities
{
    /// <summary>
    /// A static entity. Has no movement, AI or health.
    /// </summary>
    public class BEntity
    {
        public Vector2 position;
        protected Vector2 size;

        protected BTexture spritesheet;
        protected RectangleF currentSprite;
        protected RectangleF collisionBox;
        protected RectangleF drawBox;

        
        public BEntity(Vector2 position, BTexture spriteSheet)
        {
            this.position = position;
            this.spritesheet = spriteSheet;

            size = new Vector2(32f);
            currentSprite = new RectangleF(0, 0, spriteSheet.Width, spriteSheet.Height);
            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y /2), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, BTexture spriteSheet, RectangleF spriteBox)
        {
            this.position = position;
            this.spritesheet = spriteSheet;
            this.currentSprite = spriteBox;

            size = new Vector2(32f);
            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y / 2), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, BTexture spriteSheet, Vector2 size, RectangleF spriteBox)
        {
            this.position = position;
            this.size = size;
            this.spritesheet = spriteSheet;
            this.currentSprite = spriteBox;

            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y / 2), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, BTexture spriteSheet, Vector2 size, RectangleF spriteBox, RectangleF collisionBox)
        {
            this.position = position;
            this.size = size;
            this.spritesheet = spriteSheet;
            this.currentSprite = spriteBox;
            this.collisionBox = collisionBox;

            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }

        public virtual void Update(double delta, BLevel level)
        {
        }

        public virtual void Draw()
        {
            BGraphics.Draw(
                spritesheet,
                this.position - (new Vector2(DrawBox.Width, DrawBox.Height) / 2f),
                new Vector2((DrawBox.Width / currentSprite.Width), (DrawBox.Height / currentSprite.Height)),
                Color.Transparent,
                Vector2.Zero,
                currentSprite
            ); 
            
            if (AppSettings.SETTING_DEBUG) BGraphics.DrawCollisionBox(this.position - (new Vector2(CollisionBox.Width, CollisionBox.Height) / 2f), CollisionBox);
        }

        public override bool Equals(object obj)
        {
            return obj is BEntity entity &&
                   position.Equals(entity.position) &&
                   size.Equals(entity.size) &&
                   EqualityComparer<BTexture>.Default.Equals(spritesheet, entity.spritesheet);
        }

        // GETTERS
        public Vector2 Size
        {
            get
            {
                return size;
            }
        }
        public RectangleF CollisionBox
        {
            get
            {
                return collisionBox;
            }
        }
        public RectangleF DrawBox
        {
            get
            {
                return drawBox;
            }
        }

        public RectangleF CurrentSprite
        {
            get
            {
                return currentSprite;
            }
        }

        public BTexture Spritesheet
        {
            get
            {
                return spritesheet;
            }
        }
    }
}
