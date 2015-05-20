using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using ModularSearch;
using Utility;
using log4net;

namespace DataHelper
{
   public class DbHelper
   {
      private ILog mLog = LogManager.GetLogger("Mover");
      #region Public Methods
      public bool DidCross(DbGeometry start, DbGeometry end)
      {
         using (SearchDataEntities me = new SearchDataEntities())
         {
            DbGeometry line = MakeLine(start, end);
            //get the starting polygon
            var startPoly = me.base_move.Where(f => f.geom.Contains(start)).FirstOrDefault();
            return line.Crosses(startPoly.geom);
         }
    
      }

      public double? GetLengthToIntersection(MoveValues inOutMoveValues)
      {
         mLog.Debug("Inside GetLengthToIntersection making the line");
         DbGeometry line = MakeLine(inOutMoveValues.CurrentLocation, inOutMoveValues.End);
         using (SearchDataEntities me = new SearchDataEntities())
         {
            DbGeometry startPoly = me.base_move.Where(f => f.geom.Contains(inOutMoveValues.CurrentLocation)).FirstOrDefault().geom;
            DbGeometry crossOverPoint = line.Intersection(startPoly);
            inOutMoveValues.CrosOverPoint = crossOverPoint;
            line = MakeLine(inOutMoveValues.CurrentLocation, crossOverPoint);
            return  line.Length;
         }
      }
      
      private base_move GetBoundaryPolyGon(MoveValues inOutMoveValues)
      {
         using (SearchDataEntities me = new SearchDataEntities())
         {
            var twoPolygons = from g in me.base_move
                              where g.geom.Touches(inOutMoveValues.CrosOverPoint)
                              select g;
            base_move startPoly = me.base_move.Where(f => f.geom.Contains(inOutMoveValues.CurrentLocation)).FirstOrDefault();
            base_move borderPoly = twoPolygons.Where(p => p != startPoly).FirstOrDefault();
            return borderPoly;
         }

      }
      public base_food GetFoodSite(DbGeometry inLocation)
      {
         base_food bf = null;
         using (SearchDataEntities me = new SearchDataEntities())
         {
            bf = me.base_food.Where(g => g.geom.Contains(inLocation)).FirstOrDefault() as base_food;
         }
         return bf;
      }

      public base_move GetMoveSite(DbGeometry inLocation)
      {
         base_move bm = null;
         using (SearchDataEntities me = new SearchDataEntities())
         {
            bm = me.base_move.Where(f => f.geom.Contains(inLocation)).FirstOrDefault() as base_move;
         }
         return bm;
      }

      public double? GetMoveValue(DbGeometry inLocation)
      {
         base_move bm = this.GetMoveSite(inLocation);
         return bm.PR_X;
      }

      public List<base_release> GetReleaseSites()
      {
         List<base_release> br = new List<base_release>();
         using (SearchDataEntities me = new SearchDataEntities())
         {
            br = me.base_release.ToList();
         }
         return br;
      }

      public base_risk GetRiskSite(DbGeometry inLocation)
      {
         base_risk br = null;
         using (SearchDataEntities me = new SearchDataEntities())
         {
            br = me.base_risk.Where(f => f.geom.Contains(inLocation)).FirstOrDefault() as base_risk;
         }
         return br;
      }

      public bool IsStillOnMap(DbGeometry inLocation)
      {
         bool onMap = false;
         object o;
         using (SearchDataEntities me = new SearchDataEntities())
         {
            o = me.base_social.Where(f => f.geom.Contains(inLocation)).FirstOrDefault();
            if (o != null) { onMap = true; }
         }
         return onMap;
      }

      public bool LoadMaps()
      {
         using (GisHelper gh = new GisHelper())
         {
            gh.loadFoodFiles(@"E:\SEARCHwork\Maps\Food\Ridenour_food9x9.shp");
            gh.loadMoveFiles(@"E:\SEARCHwork\Maps\Move\Ridenour_move9x9.shp");
            gh.loadReleaseFile(@"E:\SEARCHwork\Maps\Release\Ridenour_release3.shp");
            gh.loadRiskFiles(@"E:\SEARCHwork\Maps\Risk\Ridenour_risk9x9.shp");
            gh.loadSocialFiles(@"E:\SEARCHwork\Maps\Social\Ridenour_social9x9.shp");
         }
         return true;
      }
      #endregion
      #region Private Methods
      private static DbGeometry MakeLine(DbGeometry start, DbGeometry end)
      {
         StringBuilder sb = new StringBuilder();
         sb.Append(start.XCoordinate.ToString() + ' ');
         sb.Append(start.YCoordinate.ToString() + " , ");
         sb.Append(end.XCoordinate.ToString() + ' ');
         sb.Append(end.YCoordinate.ToString());
         DbGeometry line = DbGeometry.FromText("LINESTRING(" + sb.ToString() + ")", 0);
         return line;
      }
      #endregion
   }
}