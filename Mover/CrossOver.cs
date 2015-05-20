using System.Data.Entity.Spatial;
using log4net;
using Utility;

namespace Mover
{
   internal class CrossOver
   {
      private DbGeometry orgPolyGon;
      private MoveValues myMoveValues;
      private DataHelper.DbHelper dbHelper;
      private ILog mLog = LogManager.GetLogger("Mover");

      #region CTOR

      public CrossOver()
      {
         dbHelper = new DataHelper.DbHelper();
      }

      public CrossOver(MoveValues inMV)
         : this()
      {
         myMoveValues = inMV;
      }

      #endregion CTOR

      public bool DidCross()
      {
         return dbHelper.DidCross(myMoveValues.CurrentLocation, myMoveValues.End);
      }

      public void StepToBorder()
      {
         myMoveValues.CurrentLocation = myMoveValues.CrosOverPoint;
         myMoveValues.CrosOverPoint = null;
      }

      public void SetPercentTimeStepToBorder()
      {
         double? distance = dbHelper.GetLengthToIntersection(myMoveValues);
         myMoveValues.PercentTimeStep = myMoveValues.PercentTimeStep + (myMoveValues.StepLength / distance);
         mLog.Debug("after step percent step is " + myMoveValues.PercentTimeStep.ToString());
      }

      public bool WillCross()
      {
         SearchRandom sr = new SearchRandom(true);
         double? likeHere = dbHelper.GetMoveValue(myMoveValues.CurrentLocation);
         double? likeThere = dbHelper.GetMoveValue(myMoveValues.End);
         double random = sr.GetDouble();

         // see if we are going to cross over or not
         return random > likeHere / likeThere;
      }
   }
}