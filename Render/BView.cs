using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace BEngine2D.Render
{
    public enum BTweenType
    {
        Instant,
        Linear,
        QuadraticInOut,
        CubicInOut,
        QuarticOut,
    }

    public class BView
    {
        private System.Numerics.Vector2 Position { get; set; }

        /// In radians, + = clockwise
        public double Rotation;

        public double Zoom;

        private System.Numerics.Vector2 PositionGoto { get; set; }
        private System.Numerics.Vector2 PositionFrom;
        private BTweenType TweenType;
        private int CurrentStep, TweenSteps;




        public BView(System.Numerics.Vector2 startPosition, double startZoom = 1.0, double startRotation = 1.0)
        {
            Position = startPosition;
            Zoom = startZoom;
            Rotation = startRotation;
        }

        public void Update()
        {
            if (CurrentStep < TweenSteps)
            {
                CurrentStep++;

                switch (TweenType)
                {
                    case BTweenType.Linear:
                        Position = PositionFrom + (PositionGoto - PositionFrom) * GetLinear((float)CurrentStep / TweenSteps);
                        break;
                    case BTweenType.QuadraticInOut:
                        Position = PositionFrom + (PositionGoto - PositionFrom) * GetQuadraticInOut((float)CurrentStep / TweenSteps);
                        break;
                    case BTweenType.CubicInOut:
                        Position = PositionFrom + (PositionGoto - PositionFrom) * GetCubicInOut((float)CurrentStep / TweenSteps);
                        break;
                    case BTweenType.QuarticOut:
                        Position = PositionFrom + (PositionGoto - PositionFrom) * GetQuarticOut((float)CurrentStep / TweenSteps);
                        break;
                }
            }
            else
            {
                Position = PositionGoto;
            }
        }

        public void SetPosition(System.Numerics.Vector2 newPosition)
        {
            Position = newPosition;
            PositionFrom = newPosition;
            PositionGoto = newPosition;
            TweenType = BTweenType.Instant;
            CurrentStep = 0;
            TweenSteps = 0;
        }

        public void SetPosition(System.Numerics.Vector2 newPosition, BTweenType type, int numSteps)
        {
            PositionFrom = Position;
            Position = newPosition;
            PositionGoto = newPosition;
            TweenType = type;
            CurrentStep = 0;
            TweenSteps = numSteps;
        }

        public float GetDistanceFromLocation(System.Numerics.Vector2 location)
        {
            Console.WriteLine($"Player: {location}, Camera: {Position}");
            return System.Numerics.Vector2.Distance(Position, location);
        }

        public System.Numerics.Vector2 ToWorld(System.Numerics.Vector2 input)
        {
            input /= (float)Zoom;
            System.Numerics.Vector2 dX = new System.Numerics.Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            System.Numerics.Vector2 dY = new System.Numerics.Vector2((float)Math.Cos(Rotation + MathHelper.PiOver2), (float)Math.Sin(Rotation + MathHelper.PiOver2));

            return (Position + dX * input.X + dY * input.Y);
        }

        public float GetLinear(float t)
        {
            return t;
        }

        public float GetQuadraticInOut(float t)
        {
            return (t * t) / ((2 * t * t) - (2 * t) + 1);
        }

        public float GetCubicInOut(float t)
        {
            return (t * t * t) / ((3 * t * t) - (3 * t) + 1);
        }

        public float GetQuarticOut(float t)
        {
            return -((t - 1) * (t - 1) * (t - 1) * (t - 1)) + 1;
        }

        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-Position.X, -Position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ((float) -Rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)Zoom, (float)Zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
