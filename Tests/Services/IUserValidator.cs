namespace Tests.Services
{
    public interface IUserValidator
    {
        UserValidationResult Validate(User user);
    }
}