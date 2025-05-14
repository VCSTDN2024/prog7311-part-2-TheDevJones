using Org.BouncyCastle.Crypto.Generators;
using st10161149_prog7311_part2.Data;
using st10161149_prog7311_part2.Models;

namespace st10161149_prog7311_part2.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)//  && BCrypt.BCrypt.Verify(password, user.PasswordHash)
                return user;
            return null;
        }
    }
}
