using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioSpectrumPlayer
{
    public abstract class ConverterMarkupExtension<T> : System.Windows.Markup.MarkupExtension, System.Windows.Data.IValueConverter where T : class, new()
    {
        private static T _converter = null;

        public ConverterMarkupExtension()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }

    [System.Windows.Data.ValueConversion(typeof(double), typeof(double))]
    public class RatioMaintainer1 : ConverterMarkupExtension<RatioMaintainer1>
    {
        public RatioMaintainer1()
        {
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)((double)value * 450d / 125d);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)((double)value * 125d / 450d);
        }
    }
    [System.Windows.Data.ValueConversion(typeof(double), typeof(double))]
    public class RatioMaintainer2 : ConverterMarkupExtension<RatioMaintainer2>
    {
        public RatioMaintainer2()
        {
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)((double)value * 125d / 450d);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)((double)value * 450d / 125d);
        }
    }
}
