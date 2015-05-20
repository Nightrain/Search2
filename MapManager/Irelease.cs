using System;
namespace Map_Manager
{
	interface IRelease
	{
		long? FEMS { get; }
		System.Data.Entity.Spatial.DbGeometry geom { get;  }
		int ID { get;  }
		long? MALES { get;  }
		long? RELEASESIT { get; }
	}
}
