using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parser.Core
{
    public static class Simplifier
    {
        static List<int> LPosList;
        static List<int> RPosList;
        static List<SubCalc> SubCalcs = new List<SubCalc>();

        static string CalcText;
        static string SimplifiedText;

        public static string Simplify(string input)
        {
            CalcText = input;
            SimplifiedText = SeperateAndSimplify(CalcText);
            return SimplifiedText;
        }

        static string SeperateAndSimplify(string input)
        {
            if (input.Contains("("))
            {
                //we still have parenthesis
                Regex rgx = new Regex(@"\((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!))\)", RegexOptions.Compiled);
                Match m = rgx.Match(input);
                if (m.Success)
                {
                    var sc = new SubCalc() { StartPos = m.Index, EndPos = (m.Index + m.Length), SubCalcText = m.Value.Substring(1, m.Value.Length - 2) };
                    if (sc.SubCalcText.Contains("("))
                    {
                        //we have a nest, process again
                        sc.SubCalcText =  SeperateAndSimplify(sc.SubCalcText);
                        input = Rebuild(input, sc);
                    }
                    else
                    {
                        input = Rebuild(input, sc);
                    }
                }
            }
            if (input.Contains("("))
            {
                input = SeperateAndSimplify(input);
            }
            return input;
        }

        static string Rebuild(string input, SubCalc sc)
        {
            return input.Substring(0, sc.StartPos) + sc.Result + input.Substring(sc.EndPos);
        }
    }
}
