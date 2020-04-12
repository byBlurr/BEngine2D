using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace BEngine2D.Render
{
    public class BView
    {
        public Vector2 Position;

        /// In radians, + = clockwise
        public double Rotation;

        public double Zoom;

        public BView(Vector2 startPosition, double startZoom = 1.0, double startRotation = 1.0)
        {
            this.Position = startPosition;
            this.Zoom = startZoom;
            this.Rotation = startRotation;
        }

        public void Update()
        {

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
