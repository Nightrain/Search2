namespace Utility
{
   public class Init
   {
      private string animalModifiersPath;
      private string simulationPath;
      private string speciesAttributesPath;
      private string temporalModifiersPath;

      public string AnimalModifiersPath
      {
         get { return animalModifiersPath; }
         set { animalModifiersPath = value; }
      }

      public string SimulationPath
      {
         get { return simulationPath; }
         set { simulationPath = value; }
      }

      public string SpeciesAttributesPath
      {
         get { return speciesAttributesPath; }
         set { speciesAttributesPath = value; }
      }

      public string TemporalModifiersPath
      {
         get { return temporalModifiersPath; }
         set { temporalModifiersPath = value; }
      }

      public Init()
      {
         SimulationPath = @"F:\SearchInputAndBackup\XML startup files\Simulation.xml";
         AnimalModifiersPath = @"F:\SearchInputAndBackup\XML startup files\AnimalModifiers.xml";
         TemporalModifiersPath = @"F:\SearchInputAndBackup\XML startup files\Simulation.xml";
         SpeciesAttributesPath = @"F:\SearchInputAndBackup\XML startup files\TemporalModifiers.xml";
         WriteOutFile();
      }

      private void WriteOutFile()
      {
         Utility.SerializeHelper.SerializeObjectToFile("Init.ini", this);
      }
   }
}