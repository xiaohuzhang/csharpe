using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace supportfunction
{
public class SpecialFunctions
{
    //////////// Gaussian functions /////////////////////////////
    static public double n(double x) //normal pdf
    { // The probability density function.
        double A = 1.0 / Math.Sqrt(2.0 * 3.1415);
        return A * Math.Exp(-x * x * 0.5); // Math class in C#
    }
    static public double N(double x)
    { // The approximation to the cumulative normal distribution.
        double a1 = 0.4361836;
        double a2 = -0.1201676;
        double a3 = 0.9372980;
        double k = 1.0 / (1.0 + (0.33267 * x));
        if (x >= 0.0)
        {
            return 1.0 - n(x) * (a1 * k + (a2 * k * k) + (a3 * k * k * k));
        }
        else
        {
            return 1.0 - N(-x);
        }
    }
    /////////////////random number generator//////////////////////
    static public double z()
    {
        Random rand = new Random(); //reuse this if you are generating many
        double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
        double u2 = rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        return randStdNormal;
    }

}
}