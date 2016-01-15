using System;
using Autofac;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class BlocNotasModulo:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>()
                .As<IServicioDatos>().SingleInstance();

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            })
            ;

        }
    }
}