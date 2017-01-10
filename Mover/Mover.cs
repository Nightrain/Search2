using log4net;
using System;
using System.Data.Entity.Spatial;
using Utility;
using DataHelper;


namespace Mover
{
   public class Mover
   {
      private ILog mLog = LogManager.GetLogger("moverLog");

      public virtual void move(MoveValues inMoveValues)
      {
         DbHelper dbHelper = new DbHelper();
         DbGeometry here = null;

        
         try
         {
            mLog.Debug(" inside move method with animal passed in " + inMoveValues.Id.ToString());
            //get specs
            //get terrain modifiers from polygon

            do
            {
               double? stepLen = inMoveValues.StepLength * (1 - inMoveValues.PercentTimeStep);//determine step length
               double? turt = inMoveValues.Turt;//determine turtosity
               inMoveValues.Angle = this.GetTurnAngle(turt);//determine turn angle

               mLog.Debug("step length is " + stepLen.ToString());
               mLog.Debug("turt is " + turt.ToString());
               mLog.Debug("angle is " + inMoveValues.Angle.ToString());
               mLog.Debug("Heading is " + inMoveValues.Heading.ToString());
               mLog.Debug("currLocation location is X = " + inMoveValues.StartValues());
               mLog.Debug("now calling step");
               here = inMoveValues.CurrentLocation;//get current location
               if (inMoveValues.PercentTimeStep > 0)
               {
                  inMoveValues.Angle = 0; //keep originMoveValuesl heading if partial time step
               }

               //move
               step(inMoveValues);//get new location
               mLog.Debug("after step heading is " + inMoveValues.Heading.ToString());

               inMoveValues.Heading = (inMoveValues.Heading + inMoveValues.Angle);//set new heading
               mLog.Debug("new heading is " + inMoveValues.Heading.ToString());
               mLog.Debug("the new  location is  " + inMoveValues.EndValues());
               mLog.Debug("now make sure the end point is on the map");

               #region Comments

               ValidateStepEnd(inMoveValues, dbHelper);
            } while (inMoveValues.PercentTimeStep < 1.0);
         }
         catch(System.Exception ex)
         {}
         }
                 
                  //     co.StepToBorder();

             
               //   mLog.Debug("cross over info");
               //   mLog.Debug("did we cross over any polyons = " + co.ChangedPolys.ToString());
               //   mLog.Debug("CurrPolyValue = " + co.CurrPolyValue.ToString());
               //   mLog.Debug("NewPolyValue = " + co.NewPolyValue.ToString());
               //   mLog.Debug("Distance = " + co.Distance.ToString());
               //   mLog.Debug(" X = " + co.Point.X.ToString() + " Y = " + co.Point.Y.ToString());
               //   mLog.Debug("George is on the map = " + co.OnTheMap.ToString());

               //check if this pushed us into a new polygon
               //Wednesday, August 23, 2006 changed from length = length OR polyValue = polyValue
               //length = length AND polyValue = polyValue
               //	if (co.ChangedPolys == false)
               //	//went the full distance stayed inside the same polygon the whole time
               //	{

            #endregion Comments



               #region Commented Out

               //	}
               //	else //new poly, move to border,decide if you want to go or not, set percentTimeStep
               //	{
               //		double likeHere = 0.0;
               //		double likeThere = 0.0;
               //		double distToBorder = 0.0;
               //		double crossoverRatio = 0.0;
               //		PointClass borderCrossing = null;

               //		mLog.Debug("different polygon so now lets get to it");
               //		mLog.Debug("calling mapmanager get cross over inFo");

               //		//move to border
               //		borderCrossing = co.Point;//get point on border
               //		inMoveValues.Location = borderCrossing;//move to border

               //		//decide if you want to go or not
               //		likeHere = co.CurrPolyValue;//get the field that represents an animal's affinity for the current polygon
               //		likeThere = co.NewPolyValue;//get the field that represents an animal's affinity for the new polygon
               //		crossoverRatio = likeThere / likeHere; //calculate the ratio
               //		//compare the ratio to a uniform random [0-1]
               //		RandomNumbers rn = RandomNumbers.getInstance();

               //		if (crossoverRatio > rn.getUniformRandomNum())//crossover
               //		{
               //			mLog.Debug("I am going to cross over");
               //			//change poly to new poly
               //			//Wednesday, July 02, 2008
               //			//inMoveValues.MoveIndex = this.myMapManager.getCurrMovePolygon(co.NewPolyPoint);
               //			//if we are going to cross over then give him a nudge into the new polygon
               //			inMoveValues.Location.PutCoords(co.NewPolyPoint.X, co.NewPolyPoint.Y);
               //		}
               //		else //go back
               //		{
               //			mLog.Debug("I am not going to cross over");
               //			inMoveValues.Heading = inMoveValues.Heading + Math.PI; //turn around
               //			//Now move back into the orginMoveValuesl polygon
               //			Mover.stepForward(ref inMoveValues);
               //		}

               //		//set percentTimeStep
               //		distToBorder = co.Distance;//get dist from currLocation to border crossing
               //		percentTimeStep += (1 - percentTimeStep) * (distToBorder / stepLen);//Update percentTimeStep
               //		percentTimeStep = Math.Round(percentTimeStep, 2);//round to avoid taking steps < .01 time step
               //	}
            
               #endregion
            //else
            //{
            //   //Wandered off the rest of the world
            //   //inMoveValues.= true;
            //   //	inMoveValues.TextFileWriter.addLine("Animal has left the map");
            //   inMoveValues.PercentTimeStep = 1;
            //   return;
            //}
            //mLog.Debug("percent time step is " + percentTimeStep.ToString());
            //mLog.Debug("now the heading value is " + inMoveValues.Heading.ToString());
            //inMoveValues.updateMemory();

            //#endregion Commented Out
         //end of try

      private void ValidateStepEnd(MoveValues inMoveValues, DbHelper dbHelper)
      {
         if (dbHelper.IsStillOnMap(inMoveValues.End))
         {
            mLog.Debug("Evidentl still on the map");
            //lets see if we cross the border or not
            CrossOver co = new CrossOver(inMoveValues);
            if (co.DidCross())
            {                
               mLog.Debug("The step will cross the border, lets see if he wants to");

               co.SetPercentTimeStepToBorder();
               co.StepToBorder();
               
               if (!co.WillCross())
               { 
                  // turn him around
                   inMoveValues.Heading = inMoveValues.Heading + System.Math.PI;
               }
            }
            else
            {
               inMoveValues.PercentTimeStep = 1.0;
            }
            mLog.Debug("leaving Validate Step End with a percent time step value of " + inMoveValues.PercentTimeStep.ToString());
         }
      }

      public double GetTurnAngle(double? variance)
      {
         System.Random rand = new Random();
         //convert to radian [0,2pi)
         double angleUniform = (rand.NextDouble() * 2 * System.Math.PI);
         //convert to Wrapped Cauchy [-pi,pi]
         //per SODA source angleDelta = 2 * atan((1-rho)/((1+rho)*tan(rndAngle * deg2rad)))
         double angleWC = 2 * System.Math.Atan((1 - (double)variance) / ((1 + (double)variance) * System.Math.Tan(angleUniform)));
         //System.Console.WriteLine("New angle: " + angleWC);
         return angleWC;
      }

      

      private void step(MoveValues inOutMV)
      {
         Double? X = inOutMV.CurrentLocation.StartPoint.XCoordinate.Value;
         Double? Y = inOutMV.CurrentLocation.StartPoint.YCoordinate.Value;
         mLog.Debug("inside step with the following values");
         mLog.Debug("stepLength is " + inOutMV.StepLength.ToString());
         mLog.Debug("turnAngle is " + inOutMV.Angle.ToString());
         mLog.Debug("heading is " + inOutMV.Heading.ToString());
         mLog.Debug("currLocation x is " + X.ToString() + " currLocation y is " + Y.ToString());

         try
         {
            double? newX = X + inOutMV.StepLength * System.Math.Cos(inOutMV.Heading + inOutMV.Angle);
            double? newY = Y + inOutMV.StepLength * System.Math.Sin(inOutMV.Heading + inOutMV.Angle);
            DbGeometry EndPoint = DbGeometry.FromText("POINT(" + newX.ToString() + " " + newY.ToString() + ")", 0);
            inOutMV.End = EndPoint;
         }
         catch (System.Exception ex)
         {
            mLog.Debug(ex);
         }
      }//end of step

      private void changePolygons(DbGeometry endStep, bool onMap)
      {
         DbHelper db = new DbHelper();
         onMap = db.IsStillOnMap(endStep);

      }
   }
}