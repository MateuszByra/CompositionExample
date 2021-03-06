﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses
{
    class Program
    {
        static void Main(string[] args)
        {
            IPainter localPintersCo =
                new PaintingCompany(
                    new IPainter[]
                    {
                        new Painter("Andy",7),
                        new Painter("Bill",5)
                    }, new WholeHouseScheduler());

            IPainter bestPaintersCo =
                new PaintingCompany(
                    new IPainter[]
                    {
                        new Painter("Joe",4),
                        new Painter("Jill",5),
                        new Painter("Buster",3),
                        localPintersCo
                    }, new ProportionalScheduler());


            LandOwner owner = new LandOwner(14, bestPaintersCo);


            owner.MaintainHouses();

            Console.WriteLine("Press ENTER to exit ...");
            Console.ReadLine();
        }
    }
}
