namespace mydll {
    static public class Mathdll {
        static public unsafe int Sum(int x, int y) {
            int* ptr = &x;
            *ptr += y;
            return *ptr;
        }

        static public unsafe int Subtract(int x, int y) {
            int* ptr = &x;
            *ptr -= y;
            return *ptr;
        }

        static public unsafe int Multiply(int x, int y) {
            int* ptr = &x;
            *ptr *= y;
            return *ptr;
        }

        static public unsafe int Devide(int x, int y) {
            int* ptr = &x;
            *ptr /= y;
            return *ptr;
        }

        static public unsafe int Mod(int x, int y) {
            int* ptr = &x;
            *ptr %= y;
            return *ptr;
        }

        static public unsafe int Abs(int x) {
            int* ptr = &x;
            return *ptr < 0 ? *ptr * -1 : *ptr;
        }

        static public unsafe int Gcd(int x, int y) {
            x = Abs(x);
            y = Abs(y);
            int* ptrX = &x;
            int* ptrY = &y;
            while (*ptrX > 0 && *ptrY > 0) {
                if (*ptrX > *ptrY) {
                    *ptrX %= *ptrY;
                } else {
                    *ptrY %= *ptrX;
                }
            }
            return *ptrX + *ptrY;
        }
    }
}
