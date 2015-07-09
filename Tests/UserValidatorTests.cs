using FluentAssertions;
using Tests.Services;
using Xunit;

namespace Tests
{
    public class UserValidatorTests
    {
        [Fact]
        public void normal_user_should_be_valid()
        {
            var userValidator = new UserValidator();
            userValidator.Validate(new User{Name = "john"})
                .Should().BeOfType<ValidUser>();
        }

        [Fact]
        public void user_without_name_is_invalid()
        {
            var userValidator = new UserValidator();
            var user = new User();

            var actual = userValidator.Validate(user);

            actual
                .As<InvalidUser>()
                .ShouldBeEquivalentTo(new InvalidUser {Message = UserValidator.NameIsRequired});
        }
    }
}