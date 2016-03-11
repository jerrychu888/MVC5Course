namespace CustomerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [EmailAddress(ErrorMessage="請填入正確之Email, EX: Wang@gmail.com")]
        [Required]
        public string Email { get; set; }

        [Required]
        [電話號碼格式錯誤(ErrorMessage = "電話號碼格式錯誤,手機號碼格式為 09xx-xxxxxx")]
        //[RegularExpression(@"\d{4}-\d{6}",ErrorMessage ="手機號碼格式為 09xx-xxxxxx")]
        //[MaxLength(11, ErrorMessage="欄位長度不得大於11個字元")]
        public string 手機 { get; set; }

        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string 電話 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
