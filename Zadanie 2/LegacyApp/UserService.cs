using LegacyApp.DataAccess;
using LegacyApp.Models;
using LegacyApp.Repositories;
using LegacyApp.Services;
using LegacyApp.Validators;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly IUserDataAccess _userDataAccess;
        private readonly UserValidator _userValidator;

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, UserValidator userValidator, IUserDataAccess userDataAccess)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _userValidator = userValidator;
            _userDataAccess = userDataAccess;
        }

        public UserService()
            :this(new ClientRepository(),new UserCreditService(), new UserValidator(new CurrentTimeService()), new UserDataAccessProxy())       
        {

        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            if (!_userValidator.HasValidParameters(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }


            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            switch (client.Name)
            {
                case "VeryImportantClient":
                    //Skip credit limit
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    {

                        user.HasCreditLimit = true;
                        int creditLimit = _userCreditService.GetCreditLimit(user.FirstName, user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                        break;
                    }

                default:
                    {
                        //Do credit check
                        user.HasCreditLimit = true;
                        int creditLimit = _userCreditService.GetCreditLimit(user.FirstName, user.LastName, user.DateOfBirth);
                        user.CreditLimit = creditLimit;
                        break;
                    }
            }

            if (_userValidator.HasCreditLimitBelow(user))
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }


    }
}
