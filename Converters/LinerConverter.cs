using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF30SEP.Converters
{
    public class LinerConverter : IValueConverter
    {
        [ConstructorArgument("K")]
        public int K { get; set; }

        LinerConverter() { K = 2; }

        LinerConverter(int k) { this.K = k; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is null) return null; 

            var result = K * System.Convert.ToDouble(value, culture);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null || K < 1) return null;

            var result = System.Convert.ToDouble(value, culture) / K;

            return result;
        }
    }
}