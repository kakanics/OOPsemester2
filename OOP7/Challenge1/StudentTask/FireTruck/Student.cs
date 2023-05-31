using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruck
{
    class Student
    {
        public string name;
        public int session;
        public int HSMarks;
        public int ecatMarks;
        public double getMerit()
        {
            return (ecatMarks / 400) * 30 + (HSMarks / 1100) * 70;
        }
    }
    class DayScholar : Student
    {
        public bool isBusCardIssued;
        public string pickupPoint;
        public int busNo;
        public DayScholar(bool isBusCardIssued, string pickupPoint, int busNo)
        {
            this.isBusCardIssued = isBusCardIssued;
            this.pickupPoint = pickupPoint;
            this.busNo = busNo;
        }

        public int getBusFee()
        {
            return 500;
        }
    }
    class Hostellite : Student
    {
        public int roomNumber;
        public bool isFridgeAvailabe;
        public bool isInternetAvailable;
        public Hostellite(int roomNumber, bool isFridgeAvailabe, bool isInternetAvailable)
        {
            this.roomNumber = roomNumber;
            this.isFridgeAvailabe = isFridgeAvailabe;
            this.isInternetAvailable = isInternetAvailable;
        }

        public int getHostelFee()
        {
            return 500;
        }
    }

}
