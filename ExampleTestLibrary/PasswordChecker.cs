using System;

namespace ExampleTestLibrary
{
    public interface IUser
    {
        string Id { get; set; }
        string Password { get; set; }
    }

    
    public interface IUserRepository
    {
        IUser GetUserById(string id);
    }

    public class PasswordChecker
    {
        private readonly IUserRepository _repository;
        public PasswordChecker(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool CheckPassword(string userId, string password)
        {
            var user = _repository.GetUserById(userId);
            if(user==null) throw new ApplicationException("User is Null");
            if (string.Equals(password, user.Password)) return true;
            return false;
        }

    }
}
