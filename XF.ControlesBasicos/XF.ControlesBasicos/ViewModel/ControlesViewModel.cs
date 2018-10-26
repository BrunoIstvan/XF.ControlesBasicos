using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF.ControlesBasicos.ViewModel
{
    public class ControlesViewModel : INotifyPropertyChanged
    {
        private bool permitirReceberEmail;
        public bool PermitirReceberEmail
        {
            get { return permitirReceberEmail; }
            set
            {
                permitirReceberEmail = value;
                if (!permitirReceberEmail) Email = string.Empty;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnAlterarPropriedade();
            }
        }

        public ICommand OnEnviar { get; set; }

        public ICommand OnConfiguracao { get; set; }

        public ControlesViewModel()
        {
            OnEnviar = new Command(Enviar);
            OnConfiguracao = new Command(AbrirConfiguracao);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnAlterarPropriedade( [CallerMemberName] string propriedade = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }


        public void Enviar()
        {
            if(PermitirReceberEmail) { 
                if(string.IsNullOrWhiteSpace(Email))
                {
                    App.Current.MainPage.DisplayAlert("Mensagem", "E-mail não informado", "OK");
                }
                else
                { 
                    App.Current.MainPage.DisplayAlert("Mensagem", $"E-mail enviado para {Email}", "OK");
                }
            } else
            {
                App.Current.MainPage.DisplayAlert("Mensagem", "E-mail não autorizado", "OK");
            }

        }

        public void AbrirConfiguracao()
        {
            App.Current.MainPage.Navigation.PushAsync(new ConfigPage() { BindingContext = App.ControlesVM } );
        }

    }
}
