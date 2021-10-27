using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.IO;

namespace Onica_Daniel_Ioan
{
    internal class Triangle : NewPoint
    {
        private NewPoint A, B, C;
        public bool IsDrawable { get; set; }

        public void Hide()
        {
            IsDrawable = false;
        }

        public void Show()
        {
            IsDrawable = true;
        }

        public void ToggleVisibility()
        {
            if (IsDrawable == true)
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
            IsDrawable = true;

            A = new NewPoint(5, 2, 0, Color.DeepPink);
            B = new NewPoint(8, 8, 0, Color.DeepPink);
            C = new NewPoint(1, 1, 0, Color.DeepPink);
        }

        public Triangle()
        {
        }

        public Triangle(NewPoint a, NewPoint b, NewPoint c)
        {
            IsDrawable = true;

            A = new NewPoint(a.getX(), a.getY(), a.getZ(), a.getColor());
            B = new NewPoint(b.getX(), b.getY(), b.getZ(), b.getColor());
            C = new NewPoint(c.getX(), c.getY(), c.getZ(), c.getColor());
        }

        public void DrawMe()
        {
            if (IsDrawable == false)
            {
                return;
            }

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(A.getColor());
            GL.Vertex3(A.getX(), A.getY(), A.getZ());
            GL.Color3(B.getColor());
            GL.Vertex3(B.getX(), B.getY(), B.getZ());
            GL.Color3(C.getColor());
            GL.Vertex3(C.getX(), C.getY(), C.getZ());

            GL.End();
        }

        public void DrawMe(int red, int green, int blue)
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.FromArgb(red, 0, 0));
            GL.Vertex3(A.getX(), A.getY(), A.getZ());
            GL.Color3(Color.FromArgb(0, green, 0));
            GL.Vertex3(B.getX(), B.getY(), B.getZ());
            GL.Color3(Color.FromArgb(0, 0, blue));
            GL.Vertex3(C.getX(), C.getY(), C.getZ());

            GL.End();
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
