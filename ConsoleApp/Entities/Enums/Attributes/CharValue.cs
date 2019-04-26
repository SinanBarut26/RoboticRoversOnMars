using System;

namespace ConsoleApp.Entities.Enums.Attributes
{
    public class CharValue : Attribute
    {
        public CharValue(char value)
        {
            this.value = value;
        }
        public char value { get; set; }
    }
}
