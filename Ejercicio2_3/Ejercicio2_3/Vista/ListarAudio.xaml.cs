using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_3.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarAudio : ContentPage
    {
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        Modelo.ModeloAudio audio;
        public ListarAudio()
        {
            InitializeComponent();
        }

        private void listaAudios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            audio = (Modelo.ModeloAudio)e.Item;
        }

        private async void btnplay_Invoked(object sender, EventArgs e)
        {
            if (audio != null)
            {
                var ruta = await App.BaseDatos.ObtenerAudio(audio.Id);
                audioPlayer.Play(ruta.Url);
            }
            else
            {
                await DisplayAlert("Notificación", "Haga clic sobre el elemento que desea reproducir o eliminar", "OK");
            }
        }

        private async void btndelete_Invoked(object sender, EventArgs e)
        {

            if (await DisplayAlert("Eliminar audio", "¿Esta seguro de eliminar el audio seleccionado: " + audio.Descripcion + " ?", "SI", "NO"))
            {
                await App.BaseDatos.EliminarAudio(audio);
                await Navigation.PopAsync();
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaAudios.ItemsSource = await App.BaseDatos.ObtenerListaAudios();
        }


    
    }
}