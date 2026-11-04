using CommunityToolkit.Maui.Views; // <-- Agrega este using para MediaElement

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            // La opacidad inicia en 0.0 al abrir la app
            ImagenDeFondo.Opacity = 0.0;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Me has tocado {count} vez";
            else
                CounterBtn.Text = $"Me has tocado {count} veces";

            SemanticScreenReader.Announce(CounterBtn.Text);

            // Incremento progresivo de la opacidad (10% por clic)
            if (ImagenDeFondo.Opacity < 1.0)
            {
                ImagenDeFondo.Opacity = Math.Min(1.0, ImagenDeFondo.Opacity + 0.1);

                if (ImagenDeFondo.Opacity >= 0.9)
                {
                    ResetBtn.IsVisible = true;
                }
            }
            // Al llegar a 14 el color se muestra en color rojo
            if (count == 14)
            {
                CounterBtn.BackgroundColor = Colors.Red;
            }

            // Al llegar a 15 clics, mostrar la ventana emergente
            if (count == 15)
            {
                OverlaySecreto.IsVisible = true;
            }
        }

        private void OnAbrirSecretoClicked(object sender, EventArgs e)
        {
            // Ocultar la emergente y reproducir el reel en pantalla completa
            OverlaySecreto.IsVisible = false;
            ReelPlayer.IsVisible = true;
            ReelPlayer.Play();
        }

        private void OnMediaEnded(object sender, EventArgs e)
        {
            // Detener el video y ocultarlo al finalizar
            ReelPlayer.Stop();
            ReelPlayer.IsVisible = false;

            // Restablecer la app a sus valores iniciales
            ReiniciarValoresIniciales();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            ReiniciarValoresIniciales();
        }

        private void ReiniciarValoresIniciales()
        {
            // Restablecer opacidad, contador y botones a sus valores por defecto
            ImagenDeFondo.Opacity = 0.0;
            count = 0;
            CounterBtn.Text = "Tocáme suave para ver los cambios";
            ResetBtn.IsVisible = false;
            OverlaySecreto.IsVisible = false;
            CounterBtn.ClearValue(Button.BackgroundColorProperty);
        }
    }
}