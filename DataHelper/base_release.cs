//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataHelper
{
    using System;
    using System.Collections.Generic;
   using System.Data.Entity.Spatial;
    
    public partial class base_release
    {
        public int ID { get; set; }
        public Nullable<long> RELEASESIT { get; set; }
        public Nullable<long> MALES { get; set; }
        public Nullable<long> FEMS { get; set; }
        public DbGeometry geom { get; set; }
    }
}
