using System;
using System.Threading;
using System.Globalization;

class Program 
{
    public static void Main ()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
        Function[] funcs = new Function[] {
            new Function1(),
            new Function2(),
            new Function3()
        };
        Integral rect = new RectIntegral(), 
                 simp = new SimpsonIntegral();
        double a = 10.4, b = 81.25, step = 0.5;

        foreach (Function f in funcs) {
            Console.Write ("Integrating {0} \nfrom {1} to {2} with step {3} \n", f, a, b, step);
            Console.Write ("- Rectangular : {0} \n", rect.Integrate(f, a, b, step));
            Console.Write ("- Simpson     : {0} \n\n", simp.Integrate(f, a, b, step));
        }

        Console.Write("{0:yyyy-MM-dd HH:mm:ss}\n", DateTime.Now);
    }
}
