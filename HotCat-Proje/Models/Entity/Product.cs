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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.order_products = new HashSet<order_products>();
        }
    
        public int ProductID { get; set; }
        public string Product_Name { get; set; }
        public int Subcategory_id { get; set; }
        public double price { get; set; }
        public int product_stock { get; set; }
        public string image { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_products> order_products { get; set; }
        public virtual subCategory subCategory { get; set; }
    }
}
