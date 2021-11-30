using System;

class Function1: Function
{
    // f(x) = x * sin(x) 
    //
    public override double Apply (double arg)
    {
        return arg * Math.Sin(arg);
    }

    public override string ToString ()
    {
        return "f(x) = x * sin(x)";
    }
}

class Function2: Function
{
    // f(x) = |x + 3|
    //
    public override double Apply (double arg)
    {
        return Math.Abs(arg + 3);
    }

    public override string ToString ()
    {
        return "f(x) = |x + 3|";
    }
}

class Function3: Function
{
    // f(x) = sin(x) * cos(x) / |x-3|
    //
    public override double Apply (double x)
    {
        return Math.Sin(x) * Math.Cos(x) / Math.Abs(x-3);
    }

    public override string ToString ()
    {
        return "f(x) = sin(x) * cos(x) / |x-3|";
    }
}
