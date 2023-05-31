using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5
{
    internal class Ship
    {
        string shipID;
        public Angle latitude;
        public Angle longitude;

        //Copy contructor, not required by question
        //public Ship(string shipID, Angle latitude, Angle longitude)
        //{
        //    this.shipID = shipID;
        //    this.latitude = latitude;
        //    this.longitude = longitude;
        //}

        //parameterized contructor
        public Ship(string shipID, int deg1, float min1, char dir1, int deg2, float min2, char dir2)
        {
            this.shipID = shipID;
            latitude = new Angle(deg1, min1, dir1);
            longitude = new Angle(deg2, min2, dir2);
        }
        public string getPosition()
        {
            string s = latitude.getAngle() + "\n" + longitude.getAngle();
            return s;
        }
        public string getShipID()
        {
            return shipID;
        }
        public void changeShipPosition(Angle latitude, Angle longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
