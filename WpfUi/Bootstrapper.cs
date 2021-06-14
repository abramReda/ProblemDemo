using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Demo.ViewModels;
using Demo.Database;
using Microsoft.EntityFrameworkCore;
using Demo.Database.Repo;

namespace Demo
{
    class Bootstrapper :BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        private AppDb _db;
        public Bootstrapper()
        {
            Initialize();

            var options = new DbContextOptionsBuilder<AppDb>()
                          .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=myData123;Integrated Security=True;")
                          .Options;

            _db = new AppDb(options);
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            //register the DataContext
            // i don't know how to add it
            _container.RegisterInstance(typeof(AppDb), null, _db); // <<<<<<<<<< how to add this correctly 
                                                                   //Register Reporisotries
            _container
                .PerRequest<IUserRepo, UserRepo>();
            //Register ViewModels
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
            //base.OnStartup(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }


        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
