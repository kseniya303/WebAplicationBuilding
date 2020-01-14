using System;

namespace Common.Attributes
{
    public class EnumTextAttribute : Attribute
    {
        public EnumTextAttribute(string val)
        {
            Value = val;
        }

        public string Value { get; }
    }
}
