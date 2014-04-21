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
      //option pricing methods
         public double analyticmethod()    
        {
              double d1=(Math.Log(s/k)+(r-0.5*vol*vol)*ttm)/(vol*Math.Sqrt(ttm));
              double d2=d1-vol*Math.Sqrt(ttm);
              double n1=supportfunction.SpecialFunctions.N(d1*optiontype);
              double n2 = supportfunction.SpecialFunctions.N(d2 * optiontype);
              double bsm=s*n1*optiontype-k*Math.Exp(-r*ttm)*optiontype*n2;
              return bsm;
        }
         public double simulation(int x)
         {
            //x:number of steps
             double st;
             double payoff_sum = 0;
             double mean=0;
             double R = (r - 0.5 * Math.Pow(vol, 2)) * ttm;
             double SD = vol * Math.Sqrt(ttm);
             for (int i = 0; i <= x; i++)
             {
                st= s* Math.Exp(R + SD * supportfunction.SpecialFunctions.z());
                payoff_sum += Math.Max(0.0, st - k);
             }
             double avgP = Math.Exp(-r*ttm)*(payoff_sum/(double)x) ;
             return avgP;
         }
       //binomial tree model
       
        }
}
       
      




