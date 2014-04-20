using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace optionpricing
{
    class Program
    {
         static void Main(string[] args)
    {
            /*Option pricing parameters */
                double s=100;
                double k=86;
                double r=0.07;
                double ttm=0.25;
                double vol=0.20;
                double optiontype = 1;
                optionpricing option=new optionpricing(s,k,ttm,r,vol,optiontype);
                double price = option.analyticmethod();
                double callprice = option.simulation();
               Console.WriteLine("{0} analytic price is :",price);
               Console.WriteLine("{0} simulation price is :",callprice);
              
         }
    }
}
