using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Validation
{
  public class NameValidation<T> : IValidationRule<T>
  {
    private ValidatableObject<T> _otherName;

    public string ValidationMessage { get; set; }

    public NameValidation(ref ValidatableObject<T> otherName)
    {
      _otherName = otherName;
    }

    public bool Check(T value)
    {
      return !(value == null || _otherName == null || value as string == _otherName.Value as string);
    }
  }
}
