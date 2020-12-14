using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Models
{
    public struct TimingPoint
    {
        public double BPM { get; }
        public double Offset { get; }
        public bool IsInherit { get; }
        
        public TimingPoint(double bpm, double offset, bool isInherit)
        {
            BPM = bpm;
            Offset = offset;
            IsInherit = isInherit;
        }
    }
}
