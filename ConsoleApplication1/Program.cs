using Animals;
using DatabaseInit;
using DataHelper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using log4net;

namespace ModularSearch
{
	internal class Program
	{
		public static List<Animals.Animal> myAnimals = new List<Animals.Animal>();
		private static AnimalManager animalManager;
		private static NameValueCollection settings = ConfigurationManager.AppSettings;
      private static ILog mlog = log4net.LogManager.GetLogger("simLog");

		public static void Main(string[] args)
		{
         mlog.Debug("Starting UP");
			bool restart = System.Convert.ToBoolean(args[0]);
			InitializeDatabase(restart);
			if (!restart) // if a restart data should be all loaded
			{
				DbHelper dh = new DbHelper();
				dh.LoadMaps();
			}
			animalManager = new AnimalManager();
			animalManager.Initialize();
			animalManager.MoveTheAnimals();

			Console.WriteLine("All done press the famous any key to continue");
			Console.ReadKey();
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

	}
}