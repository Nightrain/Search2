using MathNet.Numerics.Random;
using MathNet.Numerics;

namespace Utility
{
   public class SearchRandom
   {
      private SystemRandomSource source;
      

      public SearchRandom()
      {
        
      }

      public SearchRandom(bool ThreadSafe):base()
      {
         SystemRandomSource source = new SystemRandomSource(ThreadSafe);
      }

      public double GetDouble()
      {
         return source.NextDouble();
      }

      public double GetDouble(double inMean, double inSTDevation)
      {
         return Generate.Gaussian(1, inMean, inSTDevation)[0];
      }
   }
}