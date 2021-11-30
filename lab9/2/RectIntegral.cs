using System;

class RectIntegral: Integral
{
    public override double Integrate (Function func, double a, double b, double step) {
        double result = 0;
        double x;
        for (x = a; x < b; x += step) {
            result += this.partialIntegrate(func, x, x + step);
        }
        result += this.partialIntegrate(func, x, b);
        return result;
    }

    double partialIntegrate (Function func, double a, double b) {
        return func.Apply((a + b) / 2) * (b - a);
    }
}
