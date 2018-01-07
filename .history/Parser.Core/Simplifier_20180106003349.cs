using System.Collections.Generic;
using System.Linq;

namespace Parser.Core
{
    public static class Simplifier
    {
        static List<int> LPosList;
        static List<int> RPosList;
        static List<SubCalc> _subCalcs = new List<SubCalc>();

        static string CalcText;
        public static string Simplify(string input)
        {
            CalcText = input;
            while (CalcText.Contains("("))
            {
                GetPositions();
                var _l = LPosList.OrderByDescending(x => x).ElementAt(0);
                var _r = RPosList.OrderBy(x => x).ElementAt(0);
                var sc = new SubCalc() { StartPos = _l, EndPos = _r, SubCalcText = CalcText.Substring(_l + 1, ((_r - _l) - 1)) };
                CalcText = CalcText.Substring(0, sc.StartPos) + sc.Result + CalcText.Substring(sc.EndPos + 1, (CalcText.Length - 1) - sc.EndPos);
            }
            return CalcText;
        }

        static void GetPositions()
        {
            RPosList = new List<int>();
            LPosList = new List<int>();
            for (int p = 0; p < CalcText.Length; p++)
            {
                var _c = CalcText.Substring(p, 1);
                if (_c == "(")
                {
                    LPosList.Add(p);
                }
                if (_c == ")")
                {
                    RPosList.Add(p);
                }
            }
        }

    }
}
