using BEngine2D.Util;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace BEngine2D.Render
{
    public class BGraphics
    {
        public static void DrawTexture(BTexture2D texture)
        {
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(0, 0);

            GL.TexCoord2(1, 0);
            GL.Vertex2(1, 0);

            GL.TexCoord2(1, 1);
            GL.Vertex2(1, -1);

            GL.TexCoord2(0, 1);
            GL.Vertex2(0, -1);

            GL.End();
        }
    }
}
