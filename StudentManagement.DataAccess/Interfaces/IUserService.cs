using StudentManagement.Models;
using StudentManagement.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);

        // Note: Used by the Angular Client to show all Users !
        IEnumerable<User> GetAll();

        // TEST
        // Select all columns from the Account and the RefreshToken Table
        IEnumerable<User> GetAllX();

        // TEST
        // Select only specific columns from the Account Table
        IEnumerable GetAllY();

        // TEST
        // Select only specific columns from the Account and the RefreshToken Table
        IEnumerable GetAllZ();

        User GetById(int id);
    }
}
