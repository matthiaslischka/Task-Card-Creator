﻿// This source is subject to Microsoft Public License (Ms-PL).
// Please see https://github.com/frederiksen/Task-Card-Creator for details.
// All other rights reserved.

using System;
using System.Globalization;
using System.Windows.Data;
using ReportInterface;

namespace ScrumDetailed.Converters
{
  internal class RemainingWorkConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      try
      {
        var workItem = value as ReportItem;
        if (workItem != null)
        {
          const string fieldName = "Remaining Work";
          object estimate = workItem.Fields[fieldName];
          if (estimate != null)
          {
            object estimateString = workItem.Fields[fieldName].ToString();
            decimal estimateValue = System.Convert.ToDecimal(estimateString);

            return estimateValue/8;
          }
        }
        return "-";
      }
      catch (Exception exception)
      {
        return string.Format("Error: {0}", exception.Message);
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
