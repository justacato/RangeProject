using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeProject
{
    public interface IRange
    {
        double Left { get; set; }
        double Right { get; set; }

        string CompareRange(IRange OtherRange);
        double FindLength();
        bool IsNumberInRange(double n);
        bool AreRangesIntersecting(IRange OtherRange);

    }
}
