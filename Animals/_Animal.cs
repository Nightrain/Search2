using DataHelper;
using Utility;

namespace Animals
{
   public partial class Animal
   {
      #region fields

      private MoveValues mv = new MoveValues();
      private SearchRandom sr = new SearchRandom();
      private bool isDead = false;
      private SpeciesAttributes myAttributes = new SpeciesAttributes();
      private MovementModifiers myModifiers = new MovementModifiers();

      #endregion fields

      #region Public Methods

      public void UpdateModifiers()
      {
         DbHelper db = new DbHelper();

         GetFoodModifiers(db);
         GetMoveModifiers(db);
         // it is a one liner so leave it here
         var site = db.GetRiskSite(this.CurrLocation) as base_risk;
         this.mv.Risk = site.RISK;
      }

     
      public void WriteOutAttributes()
      {
         AnimalModifiers am = new AnimalModifiers();
         am.Type = "SafeSearchMod";
         am.CaptureFood = .5;
         am.EnergyUsed = 1;
         am.MoveSpeed = .78;
         am.MoveTurtosity = .06;
         am.PerceptonModifier = 1;
         am.PredationRisk = -1;

         myModifiers.MyAnimalModifiers.Add(am);
         TemporalModifiers tm = new TemporalModifiers();
         tm.Type = "Hourly";
         tm.StartTime = 18;
         tm.CaptureFood = 5;
         tm.EnergyUsed = 1;
         tm.MoveSpeed = .78;
         tm.MoveTurtosity = .06;
         tm.PerceptonModifier = 1;
         tm.PredationRisk = -1;
         myModifiers.myTimeModifiers.Add(tm);

         Utility.SerializeHelper.SerializeObjectToFile("modifiers.xml", myModifiers);
      }

      #endregion Public Methods

      #region Private Methods

      private void GetFoodModifiers(DbHelper db)
      {
         var foodSite = db.GetFoodSite(this.CurrLocation);
         this.mv.ChanceToEat = foodSite.PROBCAP;
         this.mv.MeanChanceToEat = foodSite.X_SIZE;
         this.mv.StdDeviationToEat = foodSite.SD_SIZE;
      }

      private void GetMoveModifiers(DbHelper db)
      {
         var site = db.GetMoveSite(this.CurrLocation);
         this.mv.EnergyUsed = site.ENERGYUSED;
         this.mv.StepLength = site.MSL;
         this.mv.Turt = site.MVL;
         this.mv.PerceptionModifier = site.PR_X;
      }

      private void Dye()
      {
         double? ChanceOfDying = this.mv.Risk * this.mv.PercentTimeStep;
         double? rollOfDice = System.Math.Abs(sr.GetDouble());
         if (rollOfDice > ChanceOfDying)
         {
            isDead = true;
         }
      }

      private void Eat()
      {
         double? ChanceOfEating = this.mv.ChanceToEat * this.mv.PercentTimeStep;
         double? rollOfDice = System.Math.Abs(sr.GetDouble());
         if (rollOfDice > ChanceOfEating)
         {
            double? foodAmt = sr.GetDouble((double)this.mv.MeanChanceToEat, (double)this.mv.StdDeviationToEat);
            this.CurrEnergy = System.Convert.ToDecimal(foodAmt) + this.CurrEnergy;
            //if(this.CurrEnergy < this.m
         }
      }

      #endregion Private Methods

      #region Properties

      public bool IsDead
      {
         get { return isDead; }
         set { isDead = value; }
      }

      public MoveValues Move_Values
      {
         get { return mv; }
         set { mv = value; }
      }

      #endregion Properties
   }
}