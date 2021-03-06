//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EHSS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class EHSSData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EHSSData()
        {
            this.Shipment = new HashSet<Shipment>();
        }
        
        public string EHSSDataID { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string PhysicalState { get; set; }
        [Required]
        public string HazardTypeCode { get; set; }
        [Required]
        public string UNNumber { get; set; }
        public Nullable<int> ExpiringInDays { get; set; }
        public string AuthorID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string EHSSStatus { get; set; }
        public string AuditorID { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public string DOTDescription { get; set; }
    
        public virtual EHSSUser EHSSUser { get; set; }
        public virtual EHSSUser EHSSUser1 { get; set; }
        public virtual HazardType HazardType { get; set; }
        public virtual MSDSData MSDSData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
