namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FileUpLoad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileUpLoad()
        {
            BaiViets = new HashSet<BaiViet>();
        }

        [Key]
        public int MaFile { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TenFile { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string ChuThichFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
