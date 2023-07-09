namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            BinhLuans = new HashSet<BinhLuan>();
            FileUpLoads = new HashSet<FileUpLoad>();
        }

        [Key]
        public int MaBaiViet { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Required]
        [StringLength(255)]
        public string TomTat { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HinhThuNho { get; set; }

        [StringLength(100)]
        public string ChuThichHinh { get; set; }

        public int LuotXem { get; set; }

        public DateTime NgayDang { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpLoad> FileUpLoads { get; set; }
    }
}
