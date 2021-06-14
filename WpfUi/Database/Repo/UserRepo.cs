using Demo.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Database.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDb _appDb;

        public UserRepo(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _appDb.Users.ToListAsync();
        }
    }
}
