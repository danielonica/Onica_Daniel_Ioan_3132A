using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.IO;

namespace Onica_Daniel_Ioan
{
    internal class Triangle 
    {
        public NewPoint A, B, C;
        private bool isDrawable;

        public Triangle()
        {
            isDrawable = true;
            A = new NewPoint(5, 2, 0, Color.DarkGoldenrod);
            B = new NewPoint(5, 5, 0, Color.DeepPink);
            C = new NewPoint(10, 5, 0, Color.DarkKhaki);
        }

        public Triangle(NewPoint P1, NewPoint P2, NewPoint P3)
        {
            isDrawable = true;
            A = P1;
            B = P2;
            C = P3;
            A.SetColor(Color.DarkGoldenrod);
            B.SetColor(Color.DeepPink);
            C.SetColor(Color.DarkKhaki);
        }
        public void Hide()
        {
            isDrawable = false;
        }

        public void Show()
        {
            isDrawable = true;
        }

        public void ToggleVisibility()
        {
            if (isDrawable == true)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        public void ManualTriangle()
        {
            isDrawable = true;

            A = new NewPoint(5, 2, 0, Color.DeepPink);
            B = new NewPoint(8, 8, 0, Color.DeepPink);
            C = new NewPoint(1, 1, 0, Color.DeepPink);
        }

       

        public void DrawMe(Triangle T)
        {
            if (isDrawable)
            {
                GL.Begin(PrimitiveType.Triangles);

                GL.Color3(T.A.pointColor);
                GL.Vertex3(T.A.X, T.A.Y, T.A.Z);
                GL.Color3(T.B.pointColor);
                GL.Vertex3(T.B.X, T.B.Y, T.B.Z);
                GL.Color3(T.C.pointColor);
                GL.Vertex3(T.C.X, T.C.Y, T.C.Z);

                GL.End();
            }
        }

        public void DrawMeColor()
        {
            if (isDrawable)
            {

                GL.Begin(PrimitiveType.TriangleStrip);

                GL.Color3(A.pointColor);
                GL.Vertex3(A.X, A.Y, A.Z);
                GL.Color3(B.pointColor);
                GL.Vertex3(B.X, B.Y, B.Z);
                GL.Color3(C.pointColor);
                GL.Vertex3(C.X, C.Y, C.Z);

                GL.End();
            }
        }

        public static Triangle ReadCoordonates(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName);
            string[] result;
            int[] numbers = new int[3];
            NewPoint[] vertex = new NewPoint[3];

            int j = 0;
            foreach (string line in lines)
            {
                int i = 0;
                result = line.Split(' ');
                foreach (string ch in result)
                {
                    numbers[i] = int.Parse(ch);
                    i++;
                }
                vertex[j] = new NewPoint(numbers[0], numbers[1], numbers[2]);
                j++;
            }
            Triangle T = new Triangle(vertex[0], vertex[1], vertex[2]);
            return T;
        }
    }
}
