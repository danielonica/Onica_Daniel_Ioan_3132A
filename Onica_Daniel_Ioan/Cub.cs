using System;
using System.Drawing;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Onica_Daniel_Ioan
{
    class Cub
    {
        public NewPoint[] cube;
        private bool myVisibility;

        public Cub()
        {
            myVisibility = true;
        }

        public Cub(string FileName)
        {
            myVisibility = true;
            this.cube = ReadCoordonates(FileName);
        }

        public Cub(NewPoint[] cub)
        {
            myVisibility = true;
            this.cube = cub;
        }

        private NewPoint[] ReadCoordonates(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                string[] infoCord;
                NewPoint[] vectorList = new NewPoint[24];
                int i = 0;
                foreach (string line in lines)
                {
                    infoCord = line.Split(' ');
                    vectorList[i] = new NewPoint(Convert.ToInt32(infoCord[0]), Convert.ToInt32(infoCord[1]), Convert.ToInt32(infoCord[2]));
                    i++;
                }
                return vectorList;
            }
        }

        public void Show()
        {
            myVisibility = true;
        }

        public void Hide()
        {
            myVisibility = false;
        }

        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }

        public void DrawMe()
        {
            int j = 0;
            if (myVisibility)
            {
                for (int i = 0; i < 6; i++)
                {
                    GL.Begin(PrimitiveType.Quads);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                }
                GL.End();
            }
        }

        public void DrawMeColor(Color[] color)
        {
            int j = 0;
            if (myVisibility)
            {
                for (int i = 0; i < 6; i++)
                {
                    GL.Color3(color[i]);
                    GL.Begin(PrimitiveType.Quads);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                    GL.Vertex3(cube[j].X, cube[j].Y, cube[j++].Z);
                }
                GL.End();
            }
        }
    }
}
