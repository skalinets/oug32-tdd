using System;

namespace Tests.Services
{
    public class UserValidator : IUserValidator
    {
        public const string NameIsRequired = "name is required";

        public UserValidationResult Validate(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name))
            {
                return new InvalidUser { Message = NameIsRequired };
            }
            return new ValidUser();
        }
    }
}