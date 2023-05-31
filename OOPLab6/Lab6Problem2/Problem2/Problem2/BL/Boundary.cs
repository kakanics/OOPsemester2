using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    internal class Boundary
    {
        public Point topLeft;
        public Point topRight;
        public Point bottomLeft;
        public Point bottomRight;

        public Boundary()
        {
            topLeft = new Point(0, 0);
            topRight = new Point(90, 0);
            bottomLeft = new Point(0, 90);
            bottomRight = new Point(90, 90);
        }
        public Boundary(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }
    }
}
