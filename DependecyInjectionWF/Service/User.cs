using System;

namespace Service
{
    public class User : IUser
    {
        public string Login()
        {
            return "Se ha logueado a un API";
        }
    }
}
