using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using supportfunction;
namespace optionpricing
{

   class optionpricing
    {
        private double s, k, ttm, r, vol;
        private double optiontype;//call for 1 put for -1

        public optionpricing(double s, double k, double ttm, double r, double vol, double optiontype)
        { 
        //constructor
            this.s = s;
            this.k = k;
            this.ttm = ttm;
            this.r = r;
            this.vol = vol;
            this.optiontype = optiontype;
        }
       /*
        static public double n(double x)
        { // The probability density function.
            double A = 1.0 / Math.Sqrt(2.0 * 3.1415);
            return A * Math.Exp(-x * x * 0.5); // Math class in C#
        }
        static public double N(double x)
        { // The approximation to the cumulative normal distribution
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
       */
         public double analyticmethod()    
        {
              double d1=(Math.Log(s/k)+(r-0.5*vol*vol)*ttm)/(vol*Math.Sqrt(ttm));
              double d2=d1-vol*Math.Sqrt(ttm);
              double n1=supportfunction.SpecialFunctions.N(d1*optiontype);
              double n2 = supportfunction.SpecialFunctions.N(d2 * optiontype);
              double bsm=s*n1*optiontype-k*Math.Exp(-r*ttm)*optiontype*n2;
              return bsm;
        }
         public double simulation()
         {
             int x = 1000;
             double [] st=new double[x];//stock price matrix
             double[] op = new double[x];//option price matrix
             double payoff_sum = 0;
             double mean=0;
             for (int i = 0; i <= st.Length-1; i++)
             {
                 st[i] = s * Math.Exp((r - 0.5 * vol * vol) * ttm + vol * Math.Sqrt(ttm) * supportfunction.SpecialFunctions.z());
                 op[i] = Math.Exp(-r * ttm)*Math.Max(st[i] - k, 0);
                 payoff_sum += op[i];
                 mean = payoff_sum / (st.Length);
             }
             double avgP = mean ;
             return avgP;
         }
   }
}
       
      




