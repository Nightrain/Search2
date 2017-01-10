using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ModularSearch
{
   [DataContract]
   public class Simulation
   {
      #region privateFields

      private DateTime _CurrentDate;
      private string strCurrentDate;

      private DateTime _StartSeasonDate;
      private string strStartDate;

      private DateTime _EndSeasonDate;
      private string strEndDate;

      private int _NumYears;
      private int _TimeBetweenSteps;
      private int _StartTime;

      #endregion privateFields

      #region Properties

      [XmlIgnore]
      public DateTime StartSeasonDate
      {
         get { return _StartSeasonDate; }
      }

      [XmlIgnore]
      public DateTime EndSeasonDate
      {
         get { return _EndSeasonDate; }
      }

      [XmlIgnore]
      public DateTime CurrentDate
      {
         get { return _CurrentDate; }
      }
      [DataMember(Name = "StartDate")]
      public string StartDate
      {
         get { return strStartDate; }
         set
         {
            strStartDate = value;
            string[] s = value.Split('/');
            _StartSeasonDate = new DateTime(System.Convert.ToInt32(s[2]), System.Convert.ToInt32(s[0]), System.Convert.ToInt32(s[1]));
         }
      }

      [DataMember(Name = "EndDate")]
      public string EndDate
      {
         get { return strEndDate; }
         set
         {
            strEndDate = value;
            string[] s = value.Split('/');
            _EndSeasonDate = new DateTime(System.Convert.ToInt32(s[2]), System.Convert.ToInt32(s[0]), System.Convert.ToInt32(s[1]));
         }
      }

      [DataMember(Name = "NumYears")]
      public int NumYears
      {
         get { return _NumYears; }
         set { _NumYears = value; }
      }

      [DataMember(Name = "TimeBetweenSteps")]
      public int TimeBetweenSteps
      {
         get { return _TimeBetweenSteps; }
         set { _TimeBetweenSteps = value; }
      }

      [DataMember(Name = "StartTime")]
      public int StartTime
      {
         get { return _StartTime; }
         set { _StartTime = value; }
      }

      #endregion Properties

      public Simulation()
      {

      }

      public void InitSimulation()
      {
         this._CurrentDate = _StartSeasonDate.AddHours(_StartTime);       
      }

      public void AdvanceOneTimeStep()
      {
         this._CurrentDate = this._CurrentDate.AddMinutes(this._TimeBetweenSteps);
      }
   }
}