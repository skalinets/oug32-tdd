using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;
using Tests.Services;
using Xunit;

namespace Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void autodata_demo()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoNSubstituteCustomization());
            var service = fixture.Create<UserService>();
            service.Should().NotBeNull();
        }

        [Theory()]
        [MyAutoData]
        public void happy_path(
            User user, 
            [Frozen] IUserRepository repository, 
            [Frozen] IUserValidator validator, 
            UserService userService)
        {
            repository.Exists(user.Name).Returns(false);
            validator.Validate(user).Returns(new ValidUser());
            
            userService.Register(user);

            repository.Received().Add(user);
        }
        
        [Theory()]
        [MyAutoData]
        public void invalid_user_should_throw(
            User user, 
            InvalidUser validationResult, 
            [Frozen] IUserValidator validator, // note we don't setup repository at all 
            UserService userService)
        {
            validator.Validate(user).Returns(validationResult);

            userService.Invoking(_ => _.Register(user))
                .ShouldThrow<Exception>(validationResult.Message); // assert on exceptions with messages
        }
    }
}
