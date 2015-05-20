using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHelper;

namespace Map_Manager
{
	 public static class Release
	 {

		 
		public static bool  GetReleaseSiteInfo(out List<float?> numMales, out List<float?> numFemales, out List<DbGeometry> location)
		 {
			 DbHelper db = new DbHelper();
			
			 bool success = true;
			 numFemales = new List<float?>();
			 numMales = new List<float?>();
			 location = new List<DbGeometry>();
			 var tempRelease = db.GetReleaseSites();

			 foreach (var rs in tempRelease)
			 {
				 
				 numFemales.Add(rs.FEMS);
				 numMales.Add(rs.MALES);
				 location.Add(rs.geom);
			 }

			 return success;
		 }

	 }
}
