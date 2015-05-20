using DataHelper;
using Utility;

namespace Map_Manager
{
	internal class Move
	{
		public void UpdateMoveModifiers(MoveValues in_outValues)
		{
			DbHelper dh = new DbHelper();
			var moveValues = dh.GetMoveSite(in_outValues.End);
			///in_outValues.Angle = moveValues.Angle;
		}
	}
}