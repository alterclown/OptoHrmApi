using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IUserService
    {
        Task<List<User>> GetUserList();
        Task<User> RetrieveUserInfo(int userId);
        Task<User> PostLoginInfo(User users);
        Task<User> RegiserNewUser(User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetUserList()
        {
            try
            {
                var res = _repository.GetUserList();
                return await res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> RetrieveUserInfo(int userId)
        {
            try
            {
                var res = _repository.RetrieveUserInfo(userId);
                return await res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> PostLoginInfo(User users)
        {
            try
            {
                var response = await _repository.PostLoginInfo(users);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<User> RegiserNewUser(User user)
        {
            try
            {
                var res = await _repository.RegiserNewUser(user);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
