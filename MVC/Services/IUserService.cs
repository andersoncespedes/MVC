using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Services;
public interface IUserService
{
    Task<string> RegisterUser(RegisterDto Model);
    Task<string> Login(LoginDto login);
}