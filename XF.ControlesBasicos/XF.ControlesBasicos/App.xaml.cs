using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.ControlesBasicos.App_Code;
using XF.ControlesBasicos.ViewModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XF.ControlesBasicos
{
	public partial class App : Application
	{
        
        public static Configuracao ConfigVM { get; set; }
        
        public static ControlesViewModel ControlesVM { get; set; }

		public App ()
		{
			InitializeComponent();

            if(ConfigVM == null) ConfigVM = new Configuracao();
            if (ControlesVM == null) ControlesVM = new ControlesViewModel();
            
			MainPage = new NavigationPage(new MainPage() { BindingContext = ControlesVM } );
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
