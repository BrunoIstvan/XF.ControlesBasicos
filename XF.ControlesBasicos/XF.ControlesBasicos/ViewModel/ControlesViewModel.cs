using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF.ControlesBasicos.ViewModel
{
    public class ControlesViewModel
    {

        public ICommand OnEnviar { get; set; }

        public ICommand OnConfiguracao { get; set; }

        public ControlesViewModel()
        {
            OnEnviar = new Command(Enviar);
            OnConfiguracao = new Command(AbrirConfiguracao);

        }

        public void Enviar()
        {
            App.Current.MainPage.DisplayAlert("Mensagem", "Email enviado para ", "OK");
            
        }

        public void AbrirConfiguracao()
        {
            App.Current.MainPage.Navigation.PushAsync(new ConfigPage() { BindingContext = App.ControlesVM } );
        }

    }
}
