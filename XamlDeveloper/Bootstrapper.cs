namespace XamlDeveloper {
    using System.Windows;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Unity;
    using Wpf.Common.Data;
    using Wpf.Common.Events;

    public class Bootstrapper : UnityBootstrapper {

        public Bootstrapper() {
        }

        // executes second
        protected override void ConfigureContainer() {
            base.ConfigureContainer();

            // load infrastructure type
            this.Container.RegisterType(typeof(IEventResolver<>), typeof(EventResolver<>));

            // register data singleton
            this.Container.RegisterType(typeof(Presentations), new ContainerControlledLifetimeManager());

        }

        // executes first
        protected override IModuleCatalog CreateModuleCatalog() {
            // load all modules listed in the app.config file
            return new ConfigurationModuleCatalog();
        }

        // executes third
        protected override DependencyObject CreateShell() {
            return this.Container.Resolve<ShellView>();
        }

        // executes fourth
        protected override void InitializeShell() {
            Application.Current.MainWindow = (ShellView)this.Shell;
            Application.Current.MainWindow.Show();
        }

    }
}
