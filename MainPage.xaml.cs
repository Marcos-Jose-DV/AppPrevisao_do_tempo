using AppPrevisaoDoTempo.Config;
using AppPrevisaoDoTempo.Models;
using AppPrevisaoDoTempo.Services;
using System.Globalization;
using System.Windows.Input;

namespace AppPrevisaoDoTempo;

public partial class MainPage : ContentPage
{
    private readonly IRestService _restService;


    public MainPage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
        SearchText.Text = "Sao paulo";
        GetWeatherData();
    }

    private void Search(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        SearchText.Text = searchBar.Text;

        if (!string.IsNullOrWhiteSpace(SearchText.Text))
        {
            GetWeatherData();
        }
    }
    private async void GetWeatherData()
    {
        try
        {
            IsBusy.IsVisible = true;
            WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestURL(Constants.OpeWeather));

            if (weatherData == null)
            {
                return;
            }

            BindingContext = weatherData;
            ConfigDate();
            GetImgTemp(weatherData);
        }
        finally
        {
            IsBusy.IsVisible = false;
        }
    }

    private void ConfigDate()
    {
        DateTime dateTime = DateTime.Now;
        var cul = new CultureInfo("pt-BR");
        string date = $"{dateTime.ToString("ddd, d", cul)} de {dateTime.ToString("MMMM HH:mm", cul)} ";
        Date.Text = date.Replace('.', ',');
    }

    private void GetImgTemp(WeatherData weatherData)
    {
        var description = weatherData.Weather[0].Description;
        string img = description switch
        {
            "céu limpo" => "sol.png",
            "nublado" => "nublado.png",
            "algumas nuvens" => "nuvens_sol.png",
            "chuva leve" => "chuva_leve.png",
            "nuvens dispersas" => "nuvens_sol.png",
            "chuva moderada" => "chuva_leve.png",
            "chuva forte" => "chuva_leve.png"         
        };
        ImageICon.Source = img;
        ImageTemp.Source = img;
    }

    private string GenerateRequestURL(string endPoint)
    {
        string requestUri = endPoint;
        requestUri += $"?q={SearchText.Text}";
        requestUri += "&units=metric";
        requestUri += $"&APPID={Constants.OpeWeatherKey}";
        requestUri += $"&lang=pt_br";
        return requestUri;
    }
}

