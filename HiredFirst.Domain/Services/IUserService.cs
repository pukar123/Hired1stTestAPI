using HiredFirst.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(string userId);
    }
}
