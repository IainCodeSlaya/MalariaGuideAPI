//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MalariaAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Infection_Cycle
    {
        public int Cycle_ID { get; set; }
        public string Cycle_Head { get; set; }
        public string Cycle_Description { get; set; }
        public Nullable<int> Malaria_ID { get; set; }
    
        public virtual Malaria Malaria { get; set; }
    }
}
