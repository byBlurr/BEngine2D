using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace BEngine2D.Render
{
    public class BGraphics
    {
        public static void Draw(BTexture2D texture, System.Numerics.Vector2 position, System.Numerics.Vector2 scale, Color color, System.Numerics.Vector2 origin, RectangleF? sourceRec = null)
        {
            System.Numerics.Vector2[] vertices = new System.Numerics.Vector2[4]
            {
                new System.Numerics.Vector2(0,0),
                new System.Numerics.Vector2(1,0),
                new System.Numerics.Vector2(1,1),
                new System.Numerics.Vector2(0,1),
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color);
            for (int i = 0; i < 4; i++)
            {
                if (sourceRec == null) GL.TexCoord2(vertices[i].X, vertices[i].Y);
                else GL.TexCoord2((sourceRec.Value.Left + vertices[i].X * sourceRec.Value.Width) / texture.Width,
                    (sourceRec.Value.Top + vertices[i].Y * sourceRec.Value.Height) / texture.Height);

                vertices[i].X *= (sourceRec == null) ? texture.Width : sourceRec.Value.Width;
                vertices[i].Y *= (sourceRec == null) ? texture.Height : sourceRec.Value.Height;
                vertices[i] -= origin;
                vertices[i] *= scale;
                vertices[i] += position;

                GL.Vertex2(vertices[i].X, vertices[i].Y);
            }

            GL.End();
        }
    
        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-screenWidth / 2.0f, screenWidth / 2.0f, screenHeight / 2.0f, -screenHeight / 2.0f, 0.0f, 1.0f);
        }
    }
}
