using MobileApp.Validation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    private string _title;
    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    private ValidatableObject<string> _first;
    public ValidatableObject<string> First
    {
      get { return _first; }
      set { SetProperty(ref _first, value); }
    }

    private ValidatableObject<string> _last;
    public ValidatableObject<string> Last
    {
      get { return _last; }
      set { SetProperty(ref _last, value); }
    }

    private ValidatableObject<string> _gpa;
    public ValidatableObject<string> GPA
    {
      get { return _gpa; }
      set { SetProperty(ref _gpa, value); }
    }

    public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      Title = "Main Page";

      First = new ValidatableObject<string>
      {
        Value = ""
      };
      Last = new ValidatableObject<string>
      {
        Value = ""
      };
      GPA = new ValidatableObject<string>
      {
        Value = ""
      };

      First.Dependents.Add(Last);
      Last.Dependents.Add(First);

      AddValidations();
    }

    private void AddValidations()
    {
      First.Validations.Add(new NameValidation<string>(ref _last)
      {
        ValidationMessage = "First name cannot be the same as last name"
      });
      Last.Validations.Add(new NameValidation<string>(ref _first)
      {
        ValidationMessage = "Last name cannot be the same as first name"
      });
      GPA.Validations.Add(new GPAValidation<string>
      {
        ValidationMessage = "GPA must be between 0.00 and 4.00"
      });
    }
  }
}
