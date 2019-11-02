using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace MobileApp.Validation
{
  public class ValidatableObject<T> : BindableBase
  {
    public List<IValidationRule<T>> Validations { get; private set; }

    private List<string> _errors;
    public List<string> Errors
    {
      get { return _errors; }
      set { SetProperty(ref _errors, value); }
    }

    private T _value;
    public T Value
    {
      get { return _value; }
      set { SetProperty(ref _value, value); Validate(); }
    }

    private bool _isValid;
    public bool IsValid
    {
      get { return _isValid; }
      set { SetProperty(ref _isValid, value); }
    }

    private List<ValidatableObject<T>> _dependents;
    public List<ValidatableObject<T>> Dependents
    {
      get { return _dependents; }
      set { SetProperty(ref _dependents, value); }
    }

    public ValidatableObject()
    {
      _isValid = true;
      _errors = new List<string>();
      Validations = new List<IValidationRule<T>>();
      _dependents = new List<ValidatableObject<T>>();
    }

    public bool Validate(ValidatableObject<T> caller = null)
    {
      Errors.Clear();

      IEnumerable<string> currentErrors = Validations.Where(x => !x.Check(Value)).Select(x => x.ValidationMessage);

      Errors = currentErrors.ToList();
      IsValid = !currentErrors.Any();

      foreach (var dependent in Dependents)
      {
        if (caller == null || dependent != caller)
        {
          dependent.Validate(this);
        }
      }

      return IsValid;
    }
  }
}