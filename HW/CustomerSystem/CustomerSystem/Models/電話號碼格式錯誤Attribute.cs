using System;

namespace CustomerSystem.Models
{
    public class 電話號碼格式錯誤Attribute : System.ComponentModel.DataAnnotations.DataTypeAttribute
    {
        public 電話號碼格式錯誤Attribute() : base(System.ComponentModel.DataAnnotations.DataType.Text)
        {
            
        }
        public override bool IsValid(object value)
        {
            string cellPhoneNumber = (string)value;
            if (!cellPhoneNumber.Contains("-"))
                return false;

            var phoneNum = cellPhoneNumber.Split('-');
            if (phoneNum.Length > 2)
                return false;
            if (phoneNum[0].Length != 4 || phoneNum[1].Length != 6)
                return false;

            return true;
        }
    }
}