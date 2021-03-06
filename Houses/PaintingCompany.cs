﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses
{
    public class PaintingCompany : IPainter
    {
        private IEnumerable<IPainter> painters;
        private IPaintingScheduler scheduler;

        public PaintingCompany(IEnumerable<IPainter> painters,
                                IPaintingScheduler scheduler)
        {
            this.painters = new List<IPainter>(painters);
            this.scheduler = scheduler;
        }

        public double Paint(double houses)
        {
            double totalVelocity = this.GetOverallVelocity();

            double totalDays =
                this.scheduler
                .Organize(this.painters, houses)
                .Select(record => record.Item1.Paint(record.Item2))
                .Max();
            return totalDays;
        }

        private double GetOverallVelocity()
        {
            return
                this.painters
                .Select(painter => painter.EstimateDays(1))
                .Select(daysPerHouse => 1 / (double)daysPerHouse)
                .Sum();
        }

        public double EstimateDays(double houses)
        {
            return
                this.scheduler
                .Organize(this.painters, houses)
                .Select(pair => pair.Item1.EstimateDays(pair.Item2))
                .Max();
        }
    }
}
