using System;

namespace NICEParser
{
    public class Processor
    {
        private enum OperatorEnum { NONE, ADD, SUBTRACT, MULTIPLY, DIVIDE }
        private OperatorEnum ActiveOperator { get; set; } = OperatorEnum.NONE;
        private OperatorEnum IncomingOperator { get; set; } = OperatorEnum.NONE;
        private bool ActiveOperatorLocked { get; set;  } = false;

        private string LeftDigitString { get; set; } = "";
        private bool LeftDigitLocked { get; set; } = false;

        private string RightDigitString { get; set; } = "";
        private bool RightDigitLocked { get; set; } = false;

        private void Reconcile()
        {
            switch (ActiveOperator)
            {
                case OperatorEnum.ADD:
                    LeftDigitString = (double.Parse(LeftDigitString) + double.Parse(RightDigitString)).ToString();
                    break;
                case OperatorEnum.SUBTRACT:
                    LeftDigitString = (double.Parse(LeftDigitString) - double.Parse(RightDigitString)).ToString();
                    break;
                case OperatorEnum.MULTIPLY:
                    LeftDigitString = (double.Parse(LeftDigitString) * double.Parse(RightDigitString)).ToString();
                    break;
                case OperatorEnum.DIVIDE:
                    LeftDigitString = (double.Parse(LeftDigitString) / double.Parse(RightDigitString)).ToString();
                    break;
            }
            LeftDigitLocked = true;
            //release the right lock
            RightDigitLocked = false;
            RightDigitString = "";

            //set the active operator
            ActiveOperator = IncomingOperator;
        }

        public double Process(string input)
        {
            for (int pos = 0; pos <= input.Length; pos++)
            {
                if (pos == input.Length)
                {
                    RightDigitLocked = true;
                    Reconcile();
                } 
                else
                {
                    var _s = input.Substring(pos, 1);
                    int _i;
                    if (int.TryParse(_s, out _i) || _s == ".")
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

                        switch (_s)
                        {
                            case "+":
                                IncomingOperator = OperatorEnum.ADD;
                                break;
                            case "-":
                                IncomingOperator = OperatorEnum.SUBTRACT;
                                break;
                            case "*":
                                IncomingOperator = OperatorEnum.MULTIPLY;
                                break;
                            case "/":
                                IncomingOperator = OperatorEnum.DIVIDE;
                                break;
                            default:
                                throw new ApplicationException("Non standard character encountered (Malformed Parenthesis?)");
                        }

                        if (!ActiveOperatorLocked)
                        {
                            ActiveOperator = IncomingOperator;
                            ActiveOperatorLocked = true;
                        }
                    }

                    if (LeftDigitLocked && RightDigitLocked && ActiveOperatorLocked)
                    {
                        //we can process
                        Reconcile();
                    }
                }
                
            }
            return double.Parse(LeftDigitString);
        }
    }
}
