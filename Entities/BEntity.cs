using BEngine2D.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Entities
{
    public class BEntity
    {
        public Vector2 position;
        private Vector2 size;

        private BTexture2D spriteSheet;
        private RectangleF currentSprite;
        private RectangleF collisionBox;
        private RectangleF drawBox;

        public BEntity(Vector2 position, BTexture2D spriteSheet, RectangleF spriteBox)
        {
            this.position = position;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;

            size = new Vector2(32f);
            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, Vector2 size, BTexture2D spriteSheet, RectangleF spriteBox)
        {
            this.position = position;
            this.size = size;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;

            collisionBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }
        public BEntity(Vector2 position, Vector2 size, BTexture2D spriteSheet, RectangleF spriteBox, RectangleF collisionBox)
        {
            this.position = position;
            this.size = size;
            this.spriteSheet = spriteSheet;
            this.currentSprite = spriteBox;
            this.collisionBox = collisionBox;

            drawBox = new RectangleF(0 - (size.X / 2), 0 - (size.Y), size.X, size.Y);
        }

        public void Update(double delta)
        {
        }

        public void Draw()
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
