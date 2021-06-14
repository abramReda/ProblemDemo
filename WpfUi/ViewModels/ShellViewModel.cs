using Caliburn.Micro;
using Demo.Database.Repo;

namespace Demo.ViewModels
{
    public class ShellViewModel : Conductor<Screen>
    {

        public  ShellViewModel(IUserRepo repo)  // <<<<<<<< repo dese not contain AppDb
        {
            //var users = repo.GetAllAsync().Result; // uncoment this to make exaption 
        }

    }
}