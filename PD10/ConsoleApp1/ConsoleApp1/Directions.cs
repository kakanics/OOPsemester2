using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Directions
    {
        UP, DOWN, LEFT, RIGHT
    }
    enum HorizontalDirections
    {
        LEFT = Directions.LEFT
       ,RIGHT = Directions.RIGHT
    }
    enum VerticalDirections
    {
        UP = Directions.UP
       , DOWN= Directions.DOWN
    }
}
