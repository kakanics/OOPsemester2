﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DL.add(UL.getStudent());
            DL.add(UL.getStudent());
            DL.add(UL.getStaff());
            DL.add(UL.getStaff());
            UL.showAll();
        }
    }
}
