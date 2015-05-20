using System;
using System.Data.Entity.Spatial;

namespace Utility
{
	public class MoveValues
	{
		#region PrivateMembers


		private bool onMap;

	
		private Double angle;
		private Double heading;
		private Double location;
		private Double? percentTimeStep;

		private Double? chanceToEat;
		private Double? energyUsed;
		private Double? meanChanceToEat;
		private Double? perceptionModifier;
		private Double? risk;
		private Double? stdDeviationToEat;
		private Double? stepLength;
		private Double? turt;

      private DbGeometry crosOverPoint;   
		private DbGeometry currLocation;
		private DbGeometry end;		
		private int id;
		private int timeStep;

		#endregion PrivateMembers

		#region Properties

		public bool OnMap
		{
			get { return onMap; }
			set { onMap = value; }
		}

		public Double Angle
		{
			get { return angle; }
			set { angle = value; }
		}

		public Double? ChanceToEat
		{
			get { return chanceToEat; }
			set { chanceToEat = value; }
		}

      public DbGeometry CrosOverPoint
      {
         get { return crosOverPoint; }
         set { crosOverPoint = value; }
      }

		public DbGeometry End
		{
			get { return end; }
			set { end = value; }
		}

		public Double? EnergyUsed
		{
			get { return energyUsed; }
			set { energyUsed = value; }
		}

		public Double Heading
		{
			get { return heading; }
			set { heading = value; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public double Location
		{
			get { return location; }
			set { location = value; }
		}

		public Double? MeanChanceToEat
		{
			get { return meanChanceToEat; }
			set { meanChanceToEat = value; }
		}

		public Double? PercentTimeStep
		{
			get { return percentTimeStep; }
			set { percentTimeStep = value; }
		}

		public Double? PerceptionModifier
		{
			get { return perceptionModifier; }
			set { perceptionModifier = value; }
		}

		public Double? Risk
		{
			get { return risk; }
			set { risk = value; }
		}

		public DbGeometry CurrentLocation
		{
			get { return currLocation; }
			set { currLocation = value; }
		}

		public Double? StdDeviationToEat
		{
			get { return stdDeviationToEat; }
			set { stdDeviationToEat = value; }
		}

		public Double? StepLength
		{
			get { return stepLength; }
			set { stepLength = value; }
		}

		public int TimeStep
		{
			get { return timeStep; }
			set { timeStep = value; }
		}

		public Double? Turt
		{
			get { return turt; }
			set { turt = value; }
		}

		#endregion Properties

		public string EndValues()
		{
			return "End X " + End.XCoordinate.Value.ToString() + " Y " + End.YCoordinate.Value.ToString();
		}

		public string StartValues()
		{
			return "End X " + CurrentLocation.XCoordinate.Value.ToString() + " Y " + CurrentLocation.YCoordinate.Value.ToString();
		}
	}
}