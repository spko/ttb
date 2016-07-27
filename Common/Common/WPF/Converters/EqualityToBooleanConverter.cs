using System;
using System.Globalization;
using System.Windows.Data;

namespace Spo.ToolsTestsBenchmarks.Common.Common.WPF.Converters
{
    /// <summary>
    /// WPF value converter, comparing input object's equality with the specified parameter
    /// </summary>
    public class EqualityToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts the equality comparison between the input object and the specified parameter to a boolean. If both objects are null return value is <c>False</c> !
        /// </summary>
        /// <param name="value">The input value</param>
        /// <param name="targetType">Target type, unused here</param>
        /// <param name="parameter">Comparison value</param>
        /// <param name="culture">Culture Info, unused here</param>
        /// <returns>Result of the equality comparison action</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }

            return value.Equals(parameter);
        }

        /// <summary>
        /// Not implemented. Will throw <see cref="NotImplementedException"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
