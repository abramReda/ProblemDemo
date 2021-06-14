using Demo.Database.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Database.Repo
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllAsync();
    }
}