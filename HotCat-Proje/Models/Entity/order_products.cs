//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotCat_Proje.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_products
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
