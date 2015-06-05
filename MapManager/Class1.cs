using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Manager
{
   public class Class1
   {
      MapManager mm = new MapManager();
      MapSwitchTrigger mst = new MapSwitchTrigger();

      
    
      public void  AddMaps()
      {
         mst.Name = "Social";
         mst.Path = @"F:\SearchInputAndBackup\SearchMaps\Ridenour\Social\Ridenour_withmales";
         mst.StartDate = new DateTime(2013, 3, 20);
         mst.StartHour = 18;
         mm.MyTriggers.Add(mst);

         mst.Name = "Food";
         mst.Path = @"F:\SearchInputAndBackup\SearchMaps\Ridenour\Food\Ridenour_food9x9low";
         mst.StartDate = new DateTime(2013, 4, 20);
         mst.StartHour = 12;
         mm.MyTriggers.Add(mst);

         WriteFile();

      }

      public void WriteFile()
      {
         Utility.SerializeHelper.SerializeObjectToFile("bobmaps.xml", mm);
      }

      public MapManager GetFromFile()
      {
         return (MapManager)Utility.SerializeHelper.DeserializeFromFile("bobmaps.xml", typeof(MapManager));
      }
   }
}
