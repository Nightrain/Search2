using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using DataHelper;
using System.IO;

namespace Map_Manager
{
	/// <summary>
	/// This MapManager is only responsible for loading and unloading the maps.
	/// </summary>
	public partial class MapManager
	{

		public void LoadInitialMaps()
		{

			Console.WriteLine("Starting to load intial Maps at " + DateTime.Now.ToLongTimeString());
		//	foreach (MapManagerMapSwitchTriggers trigger in this.MapSwitchTriggers) 
			Parallel.ForEach(this.MapSwitchTriggers, trigger =>
			{

				switch (trigger.name)
				{
					case "Social":
						using (GisHelper gh = new GisHelper())
						{
							gh.loadSocialFiles(Path.Combine(trigger.Path, trigger.FileName));
						}
						break;
					case "Food":
						using (GisHelper gh = new GisHelper())
						{
							gh.loadFoodFiles(Path.Combine(trigger.Path, trigger.FileName));
						}
						break;
					case "Predation":
						using (GisHelper gh = new GisHelper())
						{
							gh.loadRiskFiles(Path.Combine(trigger.Path, trigger.FileName));
						}
						break;
					case "Move":
						using (GisHelper gh = new GisHelper())
						{
							gh.loadMoveFiles(Path.Combine(trigger.Path, trigger.FileName));
						}
						break;
					case "Dispersal":
						using (GisHelper gh = new GisHelper())
						{
							gh.loadReleaseFile(Path.Combine(trigger.Path, trigger.FileName));
						}
						break;
				}


			}//lambada expression
			);//forloop
			Console.WriteLine("Done Loading the initial maps at " + DateTime.Now.ToLongTimeString());
			
		}
	}
}
