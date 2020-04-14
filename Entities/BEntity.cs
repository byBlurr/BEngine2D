using BEngine2D.Render;
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

        protected BTexture spriteSheet;
        protected RectangleF currentSprite;
        protected RectangleF collisionBox;
        protected RectangleF drawBox;

        public BEntity(Vector2 position, BTexture spriteSheet)
        {
            this.position = position;
            this.spriteSheet = spriteSheet;

            size = new Vector2(32f);
            currentSprite = new RectangleF(0, 0, spriteSheet.Width, spriteSheet.Height);
            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, BTexture spriteSheet, RectangleF spriteBox)
        {
            this.position = position;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;

            size = new Vector2(32f);
            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, Vector2 size, BTexture spriteSheet, RectangleF spriteBox)
        {
            this.position = position;
            this.size = size;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;

            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, Vector2 size, BTexture spriteSheet, RectangleF spriteBox, RectangleF collisionBox)
        {
            this.position = position;
            this.size = size;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;
            this.collisionBox = collisionBox;

            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }

        public virtual void Update(double delta)
        {
        }

        public virtual void Draw()
        {
            BGraphics.Draw(
                spriteSheet,
                this.position,
                new Vector2(DrawBox.Width / 100f, DrawBox.Height / 100f),
                Color.Transparent,
                new Vector2(DrawBox.Width * 0.75f, DrawBox.Height * 1.75f),
                currentSprite
            );
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
    }
}
