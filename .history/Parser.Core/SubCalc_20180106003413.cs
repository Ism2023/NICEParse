using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core
{
    public class SubCalc
    {
        public int StartPos { get; set; }
        public int EndPos { get; set; }
        public string SubCalcText { get; set; }
        public int Result {
            get
            {
                Processor p = new Processor();
                return p.Process(SubCalcText);
            }
        }
    }
}
