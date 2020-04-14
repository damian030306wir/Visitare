using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Visitare
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Position> positions = new ObservableCollection<Position>();
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnLogOut(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            Pin pin = new Pin
            {
                Label = "Punkt",
                Address = "Adres",
                Type = PinType.SavedPin,
                Position = new Position(e.Position.Latitude, e.Position.Longitude)
            };
            positions.Add(new Position(e.Position.Latitude, e.Position.Longitude));
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 6
            };
            foreach(Position pos in positions)
            {
                polyline.Geopath.Add(pos);
            }
            maps.Pins.Add(pin);
            maps.MapElements.Add(polyline);
        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            maps.Pins.Clear();
            maps.MapElements.Clear();
            positions.Clear();
        }

        private async void OnRoutesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoutesPage());
        }

        private void OnNewRoutesClicked(object sender, EventArgs e)
        {

        }
    }
}
