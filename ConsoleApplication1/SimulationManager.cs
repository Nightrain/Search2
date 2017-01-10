using System;
using log4net;

namespace ModularSearch
{
   public class SimulationManager
   {
      private Simulation mySim;
      private static ILog mlog = LogManager.GetLogger("simLog");
      private DateTime currDateTime;
      private Animals.AnimalManager animalManager = new Animals.AnimalManager();

      public SimulationManager()
      {
         mySim = new Simulation();
      }

      public SimulationManager(string inPath)
         : base()
      {
         mySim = (Simulation)Utility.SerializeHelper.DeserializeFromFile(inPath, typeof(Simulation));
         mySim.InitSimulation();
         mlog.Debug("inside the ctor for simulation manager starting time is " + mySim.StartSeasonDate.AddHours(mySim.StartTime).ToLongDateString());
      }

      public void StartSimulation(Animals.AnimalManager inAM)
      {
         int i = 0;
         while (mySim.CurrentDate < mySim.EndSeasonDate)
         {
            inAM.MoveTheAnimals();
            mySim.AdvanceOneTimeStep();
            mlog.Debug("TimeStep # = " + i++.ToString());
         }
      }
   }
}