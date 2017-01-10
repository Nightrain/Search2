using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Animals
{
   public class MovementModifiers
   {
      public List<AnimalModifiers> MyAnimalModifiers;
      public List<TemporalModifiers> myTimeModifiers;
      public MovementModifiers()
      {
         MyAnimalModifiers = new List<AnimalModifiers>();
         myTimeModifiers = new List<TemporalModifiers>();
      }
   }
   public class AnimalModifiers
   {
     public string Type;
     public double CaptureFood;
     public double EnergyUsed;
     public double MoveSpeed;
     public double MoveTurtosity;
     public double PerceptonModifier;
     public  double PredationRisk;
   }

   public class TemporalModifiers:AnimalModifiers
   {
      public DateTime StartDate;
      public int StartTime;
   }
}
