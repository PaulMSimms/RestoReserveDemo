//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestoReserveDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class foodInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public foodInfo()
        {
            this.orderInfoes = new HashSet<orderInfo>();
        }
    
        public long dish_id { get; set; }
        public string dish_name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public string type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderInfo> orderInfoes { get; set; }
    }
}