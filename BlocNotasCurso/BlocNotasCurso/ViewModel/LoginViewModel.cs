using System.Collections.ObjectModel;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta { get; set; }

        public LoginViewModel(INavigator navigator, 
            IServicioDatos servicio,Session session) :
            base(navigator, servicio,session)
        {
           cmdLogin=new Command(IniciarSesion);
            cmdAlta=new Command(NuevoUsuario);
        }

        public string TituloIniciar { get { return "Inicar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario=new Usuario();
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us != null)
                {
                    Session["usuario"] = us;
                    var blocs = await _servicio.GetBlocs(us.Id);
                    
                    
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pagina de inicio";
                        viewModel.Blocs=new ObservableCollection<Bloc>(blocs);
                        
                    });
                }
                else
                {
                    var xxx = "";
                }
                
                //TODO: Aqui navegariamos a la pantalla principal o dariamos error
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void NuevoUsuario()
        {
           // await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";
            });
        }



    }
}