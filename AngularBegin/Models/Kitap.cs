//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularBegin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kitap
    {
        public int KitapId { get; set; }
        public string Kitapadi { get; set; }
        public string YayinEvi { get; set; }
        public Nullable<System.DateTime> Basimtarihi { get; set; }
        public Nullable<int> YazarId { get; set; }
    
        public virtual Yazar Yazar { get; set; }
    }
}