using LegacyApp.Models;
using LegacyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Validators
{
    public class UserValidator
    {
        private readonly ICurrentTimeService _currentTimeService;
        private const int MinAge = 21;
        private const int MinCreditLimit = 500;
        public bool HasValidName(string firstName, string lastName)
        {
            return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
        }

        public UserValidator(ICurrentTimeService currentTimeService)
        {
            _currentTimeService = currentTimeService;
        }

        public bool HasValidEmail(string email)
        {
            return  email.Contains("@") || email.Contains(".");
        }

        public bool HasAtLeast21Years(DateTime dateOfBirth)
        {
            var now = _currentTimeService.GetCurrentDateTime();
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age > MinAge;

        }

        public bool HasCreditLimitBelow(User user)
        {
            return user.HasCreditLimit && user.CreditLimit <  MinCreditLimit;
        }


        public bool HasValidParameters(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            return HasValidName(firstName, lastName) && HasValidEmail(email) && HasAtLeast21Years(dateOfBirth);
        }

    }
}
