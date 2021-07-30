using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == pass));
        }

        public User ValidateCredentials(string username)
        {
            return _context.Users.FirstOrDefault(u => (u.Username == username));
        }

        public User RefreshUserInfo (User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id)))
            {
                return null;
            }

            var result = _context.Users.SingleOrDefault(obj => obj.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider hashAlgorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = hashAlgorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public bool RevokeToken(string username)
        {
            var user = _context.Users.FirstOrDefault(u => (u.Username == username));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
    }
}
