using System.Drawing;

namespace Onica_Daniel_Ioan
{
    internal class NewPoint
    {
        private int X;
        private int Y;
        private int Z;
        private Color color = Color.Black;


        public NewPoint()
        {
        }

        public NewPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public NewPoint(int x, int y, int z, Color color)
        {
            X = x;
            Y = y;
            Z = z;
            this.color = color;
        }


     

        public void setColor(Color color)
        {
            this.color = color;
        }

        public void setX(int x)
        {
            X = x;
        }

        public void setY(int y)
        {
            Y = y;
        }

        public void setZ(int z)
        {
            Z = z;
        }

        


        public Color getColor()
        {
            return color;
        }

        public int getX()
        {
            return X;
        }

        public int getY()
        {
            return Y;
        }

        public int getZ()
        {
            return Z;
        }

    }
}
