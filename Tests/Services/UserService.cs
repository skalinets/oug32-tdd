using System;

namespace Tests.Services
{
    public class UserService
    {

        private readonly IUserValidator validator;
        private readonly IUserRepository repository;

        public UserService(IUserValidator validator, IUserRepository repository)
        {
            this.validator = validator;
            this.repository = repository;
        }

        public void Register(User user)
        {
            var validationResult = validator.Validate(user);
            ThrowIfUserIsInvalid(validationResult);
            AddIfNotExists(user);
        }

        private void AddIfNotExists(User user)
        {
            if (!repository.Exists(user.Name))
            {
                repository.Add(user);
            }
        }

        private static void ThrowIfUserIsInvalid(UserValidationResult validationResult)
        {
            var invalidUser = (validationResult as InvalidUser);
            if (invalidUser != null)
            {
                throw new Exception(invalidUser.Message);
            }
        }
    }
}