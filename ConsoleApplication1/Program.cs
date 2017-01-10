using System;
using System.Collections.Specialized;
using System.Configuration;
using DatabaseInit;
using DataHelper;
using log4net;
using Utility;

namespace ModularSearch
{
   internal class Program
   {
      //	public static List<Animals.Animal> myAnimals = new List<Animals.Animal>();
      //	private static AnimalManager myAnimalManager;
      private static NameValueCollection settings = ConfigurationManager.AppSettings;

      private static ILog mlog = log4net.LogManager.GetLogger("simLog");
      private static SimulationManager mySimManager = new SimulationManager(settings["Simulation"]);
      private static Simulation mySimulation = new Simulation();

      public static void Main(string[] args)
      {
         mlog.Debug("Starting UP");
         if (ArgsOk(args))
         {
            bool restart = System.Convert.ToBoolean(args[0]);
            string baseInitiailizationFile = args[1];


            Animals.AnimalManager am = new Animals.AnimalManager();
            InitializeDatabase(restart);
            if (!restart) // if a restart data should be all loaded
            {
               DbHelper dh = new DbHelper();
               dh.LoadMaps();
               Init i = (Init)Utility.SerializeHelper.DeserializeFromFile(baseInitiailizationFile, typeof(Init));
               am.Initialize(i);
            }
            else
            {
               am.ReloadTheAnimals();
            }
            mySimManager.StartSimulation(am);
            Console.WriteLine("All done press the famous any key to continue");
            Console.ReadKey();
           
         }

        
       
         
      }

      private static bool InitializeDatabase(bool restart)
      {
         bool DatabaseOK = false;

         DatabaseOK = FindDatabaseServer.CheckDatabaseExists(settings["Server"], settings["Database"]);
         if (restart && DatabaseOK)
         {
            if (ValidateDatabase.HasCorrectDataTables(settings["Server"], settings["Database"]))
            {
               DatabaseOK = ValidateDatabase.HasCorrectColumns(settings["Server"], settings["Database"]);
            }
         }
         else
         {
            DatabaseOK = DatabaseInitializer.CreateDatabase(settings["Server"]);
         }

         return DatabaseOK;
      }

      /// <summary>
      /// Checks there are the correct number (2) of arguments
      /// And validates the first one is a boolean value.
      /// </summary>
      /// <param name="inArgs"></param>
      /// <returns></returns>
      private static bool ArgsOk(string[] inArgs)
      {
         bool OK = false;
         string errorMessage = "There must be two arguments.  First is the true false if this is the restart.  Second is the path to the ini file";

         if (inArgs.GetLength(0) == 2)
         {
            Boolean.TryParse(inArgs[0], out OK);
            if (OK)
               return OK;
            else throw new ArgumentException(errorMessage);
         }
         else
            throw new ArgumentException(errorMessage);
      }
   }
}
/*
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
} * */