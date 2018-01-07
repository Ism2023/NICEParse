using System;

namespace Parser.Core
{
    public class Processor
    {
        private enum OperatorEnum { ADD, SUBTRACT, MULTIPLY, DIVIDE }
        private enum LastKnownTypeEnum { NULL, VALUE, OPERATOR }

        private OperatorEnum CurrentOperator { get; set; }
        private LastKnownTypeEnum LastKnownType { get; set; } = LastKnownTypeEnum.NULL;

        private bool ParenthesisOpen { get; set; } = false;

        private string LeftDigitString { get; set; } = "";
        private bool LeftDigitLocked { get; set; } = false;

        private string RightDigitString { get; set; } = "";
        private bool RightDigitLocked { get; set; } = false;

        private int CurrentTotal { get; set; }

        public int Process(string input) 
        {
            for(int pos = 1; pos <= input.Length; pos ++) 
            {
                var _s = input.Substring(pos, 1);
                int _i;
                if (int.TryParse(_s, out _i))
                {
                    if (!LeftDigitLocked)
                    {
                        LeftDigitString = LeftDigitString + _s;
                    } 
                    else
                    {
                        if (!RightDigitLocked) 
                        {
                            RightDigitString = RightDigitString + _s;
                        }
                    }
                    LastKnownType = LastKnownTypeEnum.VALUE;
                } 
                else
                {
                    //the first time we hit this we need to ensure we lock the left digit
                    if (!LeftDigitLocked) 
                    {
                        LeftDigitLocked = true;
                    } 
                    else
                    {
                        if (!RightDigitLocked) 
                        {
                            RightDigitLocked = true;
                        }                       
                    }
                    switch(_s)
                    {
                        case "+":
                            CurrentOperator = OperatorEnum.ADD;
                            break;
                        case "-":
                            CurrentOperator = OperatorEnum.SUBTRACT;
                            break;
                        case "*":
                            CurrentOperator = OperatorEnum.MULTIPLY;
                            break;
                        case "/":
                            CurrentOperator = OperatorEnum.DIVIDE;
                            break;
                        // case "(":
                        //     if (ParenthesisOpen) throw new ApplicationError("Malformed Parenthesis");
                        //     ParenthesisOpen = true;
                        //     break;
                        // case ")":
                        //     break;
                    }

                    if (LastKnownType == LastKnownTypeEnum.VALUE)
                    {
                        //operator follows digit, find out which one's locked..
                        if (RightDigitLocked) 
                        {
                            //we can process
                            switch(CurrentOperator)
                            {
                                case OperatorEnum.ADD:
                                    CurrentTotal = int.Parse(LeftDigitString) + int.Parse(RightDigitString);
                                    break;
                                case OperatorEnum.SUBTRACT:
                                    CurrentTotal = int.Parse(LeftDigitString) - int.Parse(RightDigitString);
                                    break;
                                case OperatorEnum.MULTIPLY:
                                    CurrentTotal = int.Parse(LeftDigitString) * int.Parse(RightDigitString);
                                    break;
                                case OperatorEnum.DIVIDE:
                                    CurrentTotal = int.Parse(LeftDigitString) / int.Parse(RightDigitString);
                                    break;
                            }
                            //release the locks
                            LeftDigitLocked = false;
                            LeftDigitString = "";
                            RightDigitLocked = false;
                            RightDigitString = "";
                        }
                    }
                    LastKnownType = LastKnownTypeEnum.OPERATOR;
                }
            }
            return CurrentTotal;
        }
    }
}
