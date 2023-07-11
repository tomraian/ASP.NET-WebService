namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            BaiViets = new HashSet<BaiViet>();
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HinhDaiDien { get; set; }

        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChi { get; set; }

        public int SDT { get; set; }

        public byte GioiTinh { get; set; }

        public int VaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual VaiTro VaiTro1 { get; set; }
    }
}
