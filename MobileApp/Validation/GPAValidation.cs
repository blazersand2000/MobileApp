using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Validation
{
  public class GPAValidation<T> : IValidationRule<T>
  {
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
      if (value == null || !float.TryParse(value as string, out float gpa))
      {
        return false;
      }

      return gpa >= 0f && gpa <= 4f;
    }
  }
}
