using System;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace TestLibrary2
{
    
    public class PasswordCheckerTests
    {
        [Fact]
        public void When_User_Does_Not_Exist_Expect_Exception()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserById(Arg.Any<string>()).ReturnsNullForAnyArgs();
            var checker=new PasswordChecker(userRepository);

            Action act= () =>  checker.CheckPassword("notExisting", "x");
            
            act.ShouldThrow<ApplicationException>(); 
            userRepository.Received().GetUserById(Arg.Any<string>());
        }
        [Fact]
        public void When_User_Password_Match_Expect_True()
        {
            var userId = "u1";
            var userPass = "pass";
            var user = Substitute.For<IUser>();
            user.Id.Returns(userId);
            user.Password.Returns(userPass);
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserById(userId).Returns(user);
            var checker = new PasswordChecker(userRepository);

            var result = checker.CheckPassword(userId, userPass);

            userRepository.Received().GetUserById(userId);
            result.Should().BeTrue();
        }
        [Fact]
        public void When_User_Password_Do_Not_Match_Expect_False()
        {
            var userId = "u1";
            var userPass = "pass";
            var user = Substitute.For<IUser>();
            user.Id.Returns(userId);
            user.Password.Returns(userPass);
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserById(userId).Returns(user);
            var checker = new PasswordChecker(userRepository);

            var result = checker.CheckPassword(userId, "wrongPass");

            userRepository.Received().GetUserById(userId);
            result.Should().BeFalse();
        }
    }
}
