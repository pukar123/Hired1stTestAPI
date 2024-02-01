using HiredFirst.Domain.DbEntities;
using HiredFirst.Domain.DTO;
using HiredFirst.Domain.Repos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.Services.Implementations
{
    public class UserService:IUserService
    {
        IBaseRepository<AppUser> _userRepo;
        IBaseRepository<Product> _productRepo;

        public UserService(IBaseRepository<AppUser> userRepo, IBaseRepository<Product> productRepo)
        {
            _userRepo = userRepo;
            _productRepo = productRepo;
            
        }

        public List<UserDTO> GetAllUsers()
        {
            var result =new List<UserDTO>();
            var dbresult = _userRepo.GetAll().ToList();
            MapDBEntityToDTO(dbresult, result);
            return result;

        }
        public void UpdateUser(UserDTO userDTO)
        {
            var user = _userRepo.GetById(userDTO.UserId);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            user.FirstName= userDTO.FirstName;
            user.LastName= userDTO.LastName;
            _userRepo.UpdateAsync(userDTO.UserId,user);
            
        }
        private string RemoveHyphens(string input)
        {
            return input.Replace("-", "");
        }
        public void DeleteUser(string userId) 
        {
            var user = _userRepo.GetById(userId.Trim());
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var haveProduct=_productRepo.GetAll().Where(x => x.UserId == userId).ToList().Any();
            if(haveProduct)
            {
                throw new Exception("Can not delete the user as it have products");
            }

            _userRepo.DeleteAsync(userId);
        }
        public void StoreResetPasswordToken(string userEmail,string token)
        {
            var user=_userRepo.GetAll().Where(a=>a.Email== userEmail).FirstOrDefault();
            user.ResetPasswordToken=token;
            _userRepo.UpdateAsync(user?.Id.ToString(), user);

        }
        private void MapDBEntityToDTO(List<AppUser> dbEntities, List<UserDTO> dtos)
        {
            foreach(var data in dbEntities)
            {
                UserDTO result= new UserDTO();
                result.FirstName= data.FirstName;
                result.LastName= data.LastName;
                result.Email= data.Email;
                result.UserId= data.Id.ToString()   ;
                dtos.Add(result);

            }
           
        }
        
        
    }
}
