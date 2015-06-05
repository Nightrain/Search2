using System.Collections.Generic;

namespace Animals
{
   public class SpeciesAttributes
   {
      public EnergyParam EnergyTriggers { get; set; }

      public TemporialParam TimeTrigger { get; set; }

      public BehavioralParam BehavioralTriggers { get; set; }

      public SpeciesAttributes()
      {
         EnergyTriggers = new EnergyParam();
         TimeTrigger = new TemporialParam();
         BehavioralTriggers = new BehavioralParam();
      }
   }

   public class EnergyParam
   {
      #region Fields (3)

      private int initialEnergy;
      private int maxEnergy;
      private int minEnergy;

      #endregion Fields

      #region Properties (3)

      public int InitialEnergy
      {
         get { return initialEnergy; }
         set { initialEnergy = value; }
      }

      public int MaxEnergy
      {
         get { return maxEnergy; }
         set { maxEnergy = value; }
      }

      public int MinEnergy
      {
         get { return minEnergy; }
         set { minEnergy = value; }
      }

      #endregion Properties
   }

   public class TemporialParam
   {
      #region Fields (2)
      private int wakeUpTime;
      private List<Duration> myDurations = new List<Duration>();

      #endregion Fields

      #region Properties (2)

      public List<Duration> MyDurations
      {
         get { return myDurations; }
         set { myDurations = value; }
      }

      public int WakeUpTime
      {
         get { return wakeUpTime; }
         set { wakeUpTime = value; }
      }

      #endregion Properties
   }

   public class Duration
   {
      public Duration()
      {
         this.type = "Sleeping";
         this.meanAmt = 12;
         this.standardDeviation = 1;
      }

      #region Fields (3)

      private int meanAmt;
      private int standardDeviation;
      private string type;

      #endregion Fields

      #region Properties (3)

      public int MeanAmt
      {
         get { return meanAmt; }
         set { meanAmt = value; }
      }

      public int StandardDeviation
      {
         get { return standardDeviation; }
         set { standardDeviation = value; }
      }

      public string Type
      {
         get { return type; }
         set { type = value; }
      }

      #endregion Properties
   }

   public class BehavioralParam
   {
      #region Fields (3)

      private int forage;
      private int riskyToSafe;
      private int safeToRisk;

      #endregion Fields

      #region Properties (3)

      public int Forage
      {
         get { return forage; }
         set { forage = value; }
      }

      public int RiskyToSafe
      {
         get { return riskyToSafe; }
         set { riskyToSafe = value; }
      }

      public int SafeToRisk
      {
         get { return safeToRisk; }
         set { safeToRisk = value; }
      }

      #endregion Properties
   }
}