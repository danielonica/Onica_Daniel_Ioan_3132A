using System.Drawing;

namespace Onica_Daniel_Ioan
{
     class NewPoint
    {
        public int X;
        public int Y;
        public int Z;
        public Color pointColor;


        public NewPoint()
        {
            X = 0;
            Y = 0;
            Z = 0;
            pointColor = Color.Black;

        }

        public NewPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            pointColor = Color.Black;

        }

        public NewPoint(int x, int y, int z, Color color)
        {
            X = x;
            Y = y;
            Z = z;
            pointColor = Color.Black;
        }




        public void SetColor(Color color)
        {
            pointColor = Color.Black;
        }

        public void SetX(int x)
        {
            X = x;
        }

        public void SetY(int y)
        {
            Y = y;
        }

        public void SetZ(int z)
        {
            Z = z;
        }

        


        public Color GetColor()
        {
            return pointColor;
;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public int GetZ()
        {
            return Z;
        }

    }
}
