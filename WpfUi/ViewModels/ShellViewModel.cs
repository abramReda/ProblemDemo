using Caliburn.Micro;
using Demo.Database.Repo;

namespace Demo.ViewModels
{
    public class ShellViewModel : Conductor<Screen>
    {

        public  ShellViewModel(IUserRepo repo)  // <<<<<<<< repo des not content Appdb
        {
            //var users = repo.GetAllAsync().Result; // uncoment this to make exaptions 
        }

    }
}