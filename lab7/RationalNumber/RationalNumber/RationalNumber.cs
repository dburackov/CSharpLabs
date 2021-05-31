using System;
using System.Globalization;

namespace Lab7 {
    class RationalNumber : IFormattable {
        public RationalNumber() {
            numerator = 0;
            denominator = 0;
            negative = false;
        }
        public RationalNumber(string str) {
            RationalNumber temp = StringToRationalNumber(str);
            numerator = temp.numerator;
            denominator = temp.denominator;
            negative = temp.negative;
        }
        public RationalNumber(RationalNumber obj) {
            numerator = obj.numerator;
            denominator = obj.denominator;
            negative = obj.negative;
        }

        private int numerator;
        private int denominator;
        private bool negative;

        public override string ToString() {
            if (numerator == 0) return "0";
            if (denominator == 1) return negative ? ("-" + numerator.ToString()) : numerator.ToString();
            if (negative) return ("-" + numerator + "/" + denominator);
            else return (numerator + "/" + denominator);
        }

        public string ToStirng(string format) {
            double res = (double)numerator / denominator;
            res = negative ? -res : res;
            return String.Format(CultureInfo.CurrentCulture, format, res);
        }

        public string ToString(string format, IFormatProvider formatProvider) {
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            double result = (double)numerator / denominator;
            result = negative ? -result : result;
            return result.ToString(format, formatProvider);
        }

        public static RationalNumber StringToRationalNumber(string str) {
            RationalNumber num = new RationalNumber();
            num.negative = false;
            str.Replace(" ", "");
            if (str.Contains(".")) {
                str = str.Replace('.', ' ');
                str = str.Replace('(', ' ');
                str = str.Replace(')', ' ');
                string[] arr = str.Split(' ');

                if (arr.Length == 2) {
                    int integerPart = 0;
                    int fractionalPart = 0;
                    try {
                        integerPart = Convert.ToInt32(arr[0]);
                        if (arr[0][0] == '-') {
                            integerPart = integerPart >= 0 ? integerPart : -integerPart;
                            num.negative = true;
                        }
                        fractionalPart = Convert.ToInt32(arr[1]);
                        if (fractionalPart < 0) throw new Exception("Unkorrect input");
                    } catch {
                        throw new Exception("Unkorrect input");
                    }
                    int tempN = fractionalPart;
                    int tempM = (int)Math.Pow(10, arr[1].Length);
                    tempN = tempM * integerPart + tempN;
                    int commonD = GCD(tempN, tempM);
                    tempM /= commonD;
                    tempN /= commonD;
                    num.numerator = tempN;
                    num.denominator = tempM;
                } else if (arr.Length == 4 && arr[3] == "") {
                    int integerPart = 0;
                    int fractionalPart = 0;
                    int periodicPart = 0;
                    try {
                        integerPart = Convert.ToInt32(arr[0]);
                        if (arr[0][0] == '-') {
                            integerPart = integerPart >= 0 ? integerPart : -integerPart;
                            num.negative = true;
                        }
                        if (arr[1].Length != 0) fractionalPart = Convert.ToInt32(arr[1]);
                        else fractionalPart = 0;
                        periodicPart = Convert.ToInt32(arr[2]);
                    } catch {
                        throw new Exception("Unkorrect input");
                    }
                    int tempN = (fractionalPart * (int)Math.Pow(10, arr[2].Length) + periodicPart) -
                                 fractionalPart;
                    int tempM = NinesByCount(arr[2].Length) * (int)Math.Pow(10, arr[1].Length);
                    tempN = integerPart * tempM + tempN;
                    int commonD = GCD(tempN, tempM);
                    tempM /= commonD;
                    tempN /= commonD;
                    num.numerator = tempN;
                    num.denominator = tempM;
                }
            } else if (str.Contains("/")) {
                string[] arr = str.Split('/');
                int tempN = 0;
                int tempM = 0;
                try {
                    tempN = Convert.ToInt32(arr[0]);
                    if (arr[0][0] == '-') {
                        tempN = tempN >= 0 ? tempN : -tempN;
                        num.negative = true;
                    }
                    tempM = Convert.ToInt32(arr[1]);
                    if (tempM == 0) throw new Exception("Unkorrect input");
                } catch {
                    throw new Exception("Unkorrect input");
                }
                num.numerator = tempN;
                num.denominator = tempM;
            } else throw new Exception("Unkorrect input");
            return num;
        }

        public static RationalNumber operator +(RationalNumber num1, RationalNumber num2) {
            RationalNumber temp = new RationalNumber();

            int tempN1 = num1.negative ? -num1.numerator : num1.numerator;
            int tempN2 = num2.negative ? -num2.numerator : num2.numerator;

            int commonM = LCM(num1.denominator, num2.denominator);
            temp.denominator = commonM;

            tempN1 = tempN1 * commonM / num1.denominator;
            tempN2 = tempN2 * commonM / num2.denominator;

            temp.numerator = tempN1 + tempN2;
            if (temp.numerator < 0) {
                temp.negative = true;
                temp.numerator = -temp.numerator;
            }

            int commonD = GCD(temp.numerator, temp.denominator);
            temp.numerator /= commonD;
            temp.denominator /= commonD;

            return temp;
        }

        public static RationalNumber operator -(RationalNumber num1, RationalNumber num2) {
            RationalNumber temp = new RationalNumber();

            int tempN1 = num1.negative ? -num1.numerator : num1.numerator;
            int tempN2 = num2.negative ? -num2.numerator : num2.numerator;

            int commonM = LCM(num1.denominator, num2.denominator);
            temp.denominator = commonM;

            tempN1 = tempN1 * commonM / num1.denominator;
            tempN2 = tempN2 * commonM / num2.denominator;

            temp.numerator = tempN1 - tempN2;
            if (temp.numerator < 0) {
                temp.negative = true;
                temp.numerator = -temp.numerator;
            }

            int commonD = GCD(temp.numerator, temp.denominator);
            temp.numerator /= commonD;
            temp.denominator /= commonD;

            return temp;
        }

        public static RationalNumber operator *(RationalNumber num1, RationalNumber num2) {
            RationalNumber temp = new RationalNumber();
            if ((num1.negative && num2.negative) || (!num1.negative && !num2.negative)) temp.negative = false;
            else temp.negative = true;

            temp.numerator = num1.numerator * num2.numerator;
            temp.denominator = num1.denominator * num2.denominator;

            int commonD = GCD(temp.numerator, temp.denominator);

            temp.numerator /= commonD;
            temp.denominator /= commonD;

            return temp;
        }

        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2) {
            if (num2.numerator == 0) throw new Exception("Division by zero");
            RationalNumber temp = new RationalNumber();
            temp.negative = num2.negative;
            temp.numerator = num2.denominator;
            temp.denominator = num2.numerator;

            return (num1 * temp);
        }

        public static bool operator >(RationalNumber num1, RationalNumber num2) {
            double n1 = (double)num1.numerator / num1.denominator;
            n1 = num1.negative ? -n1 : n1;

            double n2 = num2.numerator / num2.denominator;
            n2 = num2.negative ? -n2 : n2;

            return (n1 > n2);
        }

        public static bool operator <(RationalNumber num1, RationalNumber num2) {
            double n1 = (double)num1.numerator / num1.denominator;
            n1 = num1.negative ? -n1 : n1;

            double n2 = num2.numerator / num2.denominator;
            n2 = num2.negative ? -n2 : n2;

            return (n1 < n2);
        }

        public static bool operator >=(RationalNumber num1, RationalNumber num2) {
            double n1 = (double)num1.numerator / num1.denominator;
            n1 = num1.negative ? -n1 : n1;

            double n2 = num2.numerator / num2.denominator;
            n2 = num2.negative ? -n2 : n2;

            return (n1 >= n2);
        }

        public static bool operator <=(RationalNumber num1, RationalNumber num2) {
            double n1 = (double)num1.numerator / num1.denominator;
            n1 = num1.negative ? -n1 : n1;

            double n2 = num2.numerator / num2.denominator;
            n2 = num2.negative ? -n2 : n2;

            return (n1 <= n2);
        }

        public static bool operator ==(RationalNumber num1, RationalNumber num2) {
            return ReferenceEquals(num1, num2);
        }

        public static bool operator !=(RationalNumber num1, RationalNumber num2) {
            return !ReferenceEquals(num1, num2);
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            if (obj is RationalNumber objectType) {
                double n1 = (double)this.numerator / this.denominator;
                n1 = this.negative ? -n1 : n1;

                double n2 = (double)objectType.numerator / objectType.denominator;
                n2 = objectType.negative ? -n2 : n2;
                return (n1 == n2);
            }
            return false;
        }

        public override int GetHashCode() {
            double result = (double)numerator / denominator;
            result = negative ? -result : result;
            return result.GetHashCode();
        }

        public static implicit operator double(RationalNumber num) {
            double res = (double)num.numerator / num.denominator;
            res = num.negative ? -res : res;
            return res;
        }

        public static implicit operator float(RationalNumber num) {
            float result = (float)num.numerator / num.denominator;
            result = num.negative ? -result : result;
            return result;
        }

        public static explicit operator int(RationalNumber num) {
            double result = (double)num.numerator / num.denominator;
            result = num.negative ? -result : result;
            return (int)result;
        }

        public static explicit operator long(RationalNumber num) {
            long result = (long)num.numerator / num.denominator;
            result = num.negative ? -result : result;
            return result;
        }

        private static int GCD(int x, int y) {
            int temp;
            while (y != 0) {
                x = x % y;
                temp = y;
                y = x;
                x = temp;
            }
            return x;
        }

        private static int LCM(int x, int y) {
            return (x / GCD(x, y) * y);
        }

        private static int NinesByCount(int count) {
            int result = 0;
            for (int i = 0; i < count; i++) {
                result += 9 * (int)Math.Pow(10, i);
            }
            return result;
        }
    }
}