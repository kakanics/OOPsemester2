using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PD5
{
    internal class Angle
    {
        public float minutes;
        public int degrees;
        public char direction;

        public Angle(int _degrees, float _minutes, char _direction)
        {
            minutes = _minutes;
            degrees = _degrees;
            direction = _direction;
        }
        public string getAngle()
        {
            string s = degrees + "\u00b0" + minutes + "\'" + direction;
            return s;
        }
    }
}
