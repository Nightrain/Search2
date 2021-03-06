﻿using Map_Manager;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Utility;

namespace Animals
 //  namespace ModularSearch
{
	public class AnimalManager
	{
		#region Fields (1) 

		private List<Animal> myAnimals;
      private List<AnimalModifiers> myAnimalModifiers;
      private TemporalModifiers myTemporialModifiers;
      private static ILog mlog = LogManager.GetLogger("animalManager");

		#endregion Fields 

		#region Constructors (1) 

		//private static int change = 0;
		public AnimalManager()
		{
			myAnimals = new List<Animal>();
         //myAnimalModifiers = new List<AnimalModifiers>();
         //myAnimalModifiers = (List < AnimalModifiers > )Utility.SerializeHelper.DeserializeFromFile(@"F:\SearchInputAndBackup\XML startup files\modifiers.xml", typeof(List<AnimalModifiers>));
         //myTemporialModifiers = (TemporalModifiers)Utility.SerializeHelper.DeserializeFromFile(@"F:\SearchInputAndBackup\XML startup files\TimeModifiers.xml", typeof(TemporalModifiers));
		}

		#endregion Constructors 



		#region PublicMethods

		public void Initialize(Init inValues)
		{
			this.DeleteAllAnimals();
			this.GetNewAnimals();
         myAnimalModifiers = (List<AnimalModifiers>)Utility.SerializeHelper.DeserializeFromFile(@"F:\SearchInputAndBackup\XML startup files\modifiers.xml", typeof(List<AnimalModifiers>));
         myTemporialModifiers = (TemporalModifiers)Utility.SerializeHelper.DeserializeFromFile(@"F:\SearchInputAndBackup\XML startup files\TimeModifiers.xml", typeof(TemporalModifiers));

		}
      public void MoveTheAnimals()
		{
			Console.WriteLine("Starting Move the Animals at " + DateTime.Now.ToLongTimeString());
         mlog.Debug("Just starting move the animals");
         mlog.Debug("we are going to move " + myAnimals.Count.ToString());
	
			Mover.Mover mover = new Mover.Mover();
			for (int i = 0; i < 10; i++)
			{
				foreach (Animals.Animal a in myAnimals)
				//Parallel.ForEach(myAnimals, a =>
				{
					//no go if we walked off the map
					if (a.Move_Values.OnMap)
					{
						AnimalPath ap = new AnimalPath();
						a.Move_Values.PercentTimeStep = 0;
						ap.AnimalID = a.ID;
						ap.TimeStep = i;
						a.Move_Values.TimeStep = i;
						mover.move(a.Move_Values);
						ap.Location = a.Move_Values.End;
						a.AnimalPaths.Add(ap);
						
					}
				}
				//);
				this.UpdateAllAnimalsModifiers();
			}
			Console.WriteLine("Done moving at " + DateTime.Now.ToLongTimeString());
			Console.WriteLine("now the data base part");
			UpdateAllAnimalsLocation(myAnimals);
			Console.WriteLine("Finish Move the Animals at " + DateTime.Now.ToLongTimeString());
		}


      public void ReloadTheAnimals()
      {
         using (AnimalEntities ae = new AnimalEntities())
         {
            this.myAnimals = ae.Animals.ToList();
         }
   }
		#endregion PublicMethods


		#region PrivateMethods

		private void AddAnimalsToDB()
		{
			using (AnimalEntities animalProxy = new AnimalEntities())
			{
				animalProxy.Animals.AddRange(myAnimals);
				animalProxy.SaveChanges();
			}
		}

		private void BuildAnimals(DbGeometry inLocation, float? numAnimals, string inSex)
		{
			Animals.Animal a = new Animals.Animal();
			for (int i = 0; i < numAnimals; i++)
			{
				a = new Animals.Animal();
				a.Sex = inSex;
				a.CurrLocation = inLocation;
				a.Move_Values.CurrentLocation = inLocation;
				a.Move_Values.OnMap = true;
				a.UpdateModifiers();
				myAnimals.Add(a);
			}
		}

		private void BuildFemaleAnimals(DbGeometry inLocation, float? numAnimals)
		{
			if (numAnimals > 0)
			{
				BuildAnimals(inLocation, numAnimals, "Female");
			}
		}

		private void BuildMaleAnimals(DbGeometry inLocation, float? numAnimals)
		{
			if (numAnimals > 0)
			{
				BuildAnimals(inLocation, numAnimals, "Male");
			}
		}


      public void ChangeToDeadAnimal(Animal inA)
      {
         mlog.Debug("inside Change to dead animal for animal number " + inA.ID);
         mlog.Debug("All we are doing is actually just removing him at this point");
         myAnimals.Remove(inA);

      }

      private void DeleteAllAnimals()
		{
			using (AnimalEntities ae = new AnimalEntities())
			{
				ae.Database.ExecuteSqlCommand("Truncate Table [AnimalPath]");
				ae.Database.ExecuteSqlCommand("Delete from Animal");
				ae.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('dbo.Animal', RESEED, -1);");
				ae.SaveChanges();
			}
		}

      private void GetModifiers()
      {
         
      }
		private void GetNewAnimals()
		{
			List<float?> numFemales;
			List<float?> numMales;
			List<DbGeometry> locations;

			//	Release.GetReleaseSiteInfor(out numMales, out numFemales, out locations);

			Release.GetReleaseSiteInfo(out numMales, out numFemales, out locations);


			int numAnimals = numMales.Count;
			for (int i = 0; i < numAnimals; i++)
			{
				BuildMaleAnimals(locations[i], numMales[i]);
				BuildFemaleAnimals(locations[i], numFemales[i]);
			}
			this.AddAnimalsToDB();
		}

		private void UpdateAllAnimalsLocation(List<Animal> inA)
		{
		//	Parallel.ForEach(inA, a =>
			foreach(Animal a in inA)
				  {
					  using (AnimalEntities ae = new AnimalEntities())
					  {
						  Animal CurrAnimal = ae.Animals.Find(a.ID);
						  CurrAnimal.CurrLocation = a.Move_Values.End;
						  CurrAnimal.Move_Values.CurrentLocation = a.Move_Values.End;
						  AnimalPath path = a.AnimalPaths.LastOrDefault();
						  CurrAnimal.AnimalPaths = a.AnimalPaths;
						  ae.SaveChanges();
					  }// end using
				  }//end foreach scope
				 // );//end foreach loop
		}

		private void UpdateAllAnimalsModifiers()
		{

			//	foreach (Animal a in myAnimals)
			Parallel.ForEach(myAnimals, a =>
				{ a.UpdateModifiers(); });
		}

		#endregion PrivateMethods


   }
}//namespace 