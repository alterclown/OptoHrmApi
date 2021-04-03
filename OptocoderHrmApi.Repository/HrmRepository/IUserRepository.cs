using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();
        Task<User> RetrieveUserInfo(int userId);
        Task<User> PostLoginInfo(User users);
        Task<User> RegiserNewUser(User user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public UserRepository(IOptions<AppSettings> appSettings, DataContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<User> PostLoginInfo(User users)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == users.Email && x.Password == users.Password);

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name , user.UserId.ToString()),
                    new Claim(ClaimTypes.Role , user.IsAdmin.ToString())

                }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                user.Password = null;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<User>> GetUserList()
        {
            try
            {
                var res = await _context.Users
                           .Include(a => a.Company)
                           .ToListAsync();
                return res;
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
                var _query = _context.Users
                            .Where(s => s.UserId == userId)
                            .Select(s => s)
                            .Include(a => a.Employees).FirstOrDefaultAsync<User>();
                return await _query;
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
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
