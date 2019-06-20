using System;
using System.ComponentModel;
using System.Globalization;

namespace LogicaDeNegocio.Util
{
    public class EnumTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext 
            context, Type destinationType)
        {
            return object.ReferenceEquals(destinationType, typeof(string)) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, 
            CultureInfo culture, object value, Type destinationType)
        {
            if (!object.ReferenceEquals(destinationType, typeof(string)))
                return base.ConvertTo(context, culture, value, destinationType);
            var fi = value.GetType().GetField(value.ToString());
            var attr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length > 0 ? attr[0].Description : value.ToString();
        }
    }
}