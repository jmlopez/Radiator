using Caliburn.PresentationFramework.ApplicationModel;
using Radiator.UserInterface.ViewModels;

namespace Radiator.UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        public App()
        {
            //InitializeComponent();
        }

        protected override Microsoft.Practices.ServiceLocation.IServiceLocator CreateContainer()
        {
            return RadiatorRegistry.CreateContainer();
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<HomeViewModel>();
        }
    }
}
