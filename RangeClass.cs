using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeProject
{
    public class RangeClass : IRange
    {
        static void Main(string[] args)
        {

        }
        public double Left { get; set; }

        private double _right;
        public double Right
        {
            get => _right;
            set => _right = value <= Left ? throw new ArgumentOutOfRangeException("Right boundary cannot be lesser than the left boundary") : value;
        }

        public RangeClass(double left, double right)
        {
            Left = left;
            Right = right;
        }

        public bool AreRangesIntersecting(IRange OtherRange)
        {
            return !(Right < OtherRange.Left || Left > OtherRange.Right);
        }

        public string CompareRange(IRange OtherRange)
        {
            if (this.FindLength() > OtherRange.FindLength())
            {
                return "This range is bigger than the other range";
            }
            else
            {
                return "This range is shorter than the other range";
            }
        }

        public double FindLength()
        {
            return Right - Left;
        }

        public bool IsNumberInRange(double n)
        {
            return n >= Left && n <= Right;
        }

        public override bool Equals(object obj)
        {
            return obj is RangeClass @class &&
                   Left == @class.Left &&
                   _right == @class._right &&
                   Right == @class.Right;
        }

        public override int GetHashCode()
        {
            int hashCode = 805646265;
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + _right.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format($"Left boundary = {Left} and right boundary = {Right}");
        }
    }
}

