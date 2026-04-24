using System.Collections.Generic;
using Lab_8.Entities;
using Lab_8.Model;

namespace Lab_8.Services
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        IEnumerable<User> GetUsers();
        User GetByUsername(string username);
        User GetById(int id);
    }
}