using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class LoginViewModel
    {
        private readonly DatabaseService _databaseService;



        public LoginViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        public Employee Login(string username, string password)
        {

            return _databaseService.ValidateEmployee(username, password);
        }
    }
}
