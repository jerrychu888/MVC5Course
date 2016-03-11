using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    public class 尾數不可以為零Attribute : DataTypeAttribute
    {
        public 尾數不可以為零Attribute() : base(DataType.Text)
        {

        }
        public override bool IsValid(object value)
        {
            string input = value.ToString();
            if (input.EndsWith("0"))
            {
                return false;
            }
            return true;
            
        }

    }
}