using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Map_Manager
{
   
   public class MapManager
   {
		#region Fields (1) 
      public string name;
      [XmlArrayAttribute(ElementName = "myTriggers")]
      public List<MapSwitchTrigger> myTriggers;

		#endregion Fields 

		#region Constructors (1) 

      public MapManager()
      {
         myTriggers = new List<MapSwitchTrigger>();
      }

		#endregion Constructors 

		#region Properties (1) 

      internal List<MapSwitchTrigger> MyTriggers
      {
         get { return myTriggers; }
         set { myTriggers = value; }
      }

		#endregion Properties 
   }

   [Serializable]
   public class MapSwitchTrigger
   {
		#region Fields (4) 

      private string name;
      private string path;
      private DateTime startDate;
      private int startHour;

		#endregion Fields 

		#region Enums (1) 

      public enum TriggerType { Hourly, Daily, Static };

		#endregion Enums 

		#region Properties (4) 

      public string Name
      {
         get { return name; }
         set { name = value; }
      }

      public string Path
      {
         get { return path; }
         set { path = value; }
      }

      public DateTime StartDate
      {
         get { return startDate; }
         set { startDate = value; }
      }

      public int StartHour
      {
         get { return startHour; }
         set { startHour = value; }
      }

   
      
    
		#endregion Properties 
   }
}