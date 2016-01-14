using System;
using System.ComponentModel;

namespace BlocNotasCurso.ViewModel.Base
{
    public interface IViewModel:INotifyPropertyChanged
    {
     string Titulo { get; set; }
     void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}