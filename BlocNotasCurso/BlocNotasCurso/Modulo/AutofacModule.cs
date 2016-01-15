using Autofac;
using BlocNotasCurso.Factorias;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().
                As<IViewFactory>().
                SingleInstance();
            builder.RegisterType<Navigator>().
                As<INavigator>().SingleInstance();
            builder.Register<INavigation>(
                ctx=> App.Current.MainPage.Navigation).SingleInstance();


        }
    }
}