namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Valids;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        [StringLength(2)]
        public int MyProperty { get; set; }
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "{0}為必填欄位")]
        [DisplayName("商品名稱")]
        [StringLength(10, ErrorMessage="欄位長度不得大於 80 個字元")]
        [商品名稱不能出現123關鍵字]
        public string ProductName { get; set; }

        [Range(0, 100)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        [StringLength(1)]
        public int MyProperty { get; set; }
    }
}
