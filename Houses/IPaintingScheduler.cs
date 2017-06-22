using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses
{
    public interface IPaintingScheduler
    {
        IEnumerable<Tuple<IPainter, double>> Organize(IEnumerable<IPainter> painters, double houses);
    }
}
