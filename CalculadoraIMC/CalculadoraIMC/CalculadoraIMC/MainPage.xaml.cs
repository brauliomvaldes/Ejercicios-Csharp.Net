using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraIMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Altura.Text) && 
                !string.IsNullOrEmpty(Peso.Text))
            {
                var altura = Double.Parse(Altura.Text);
                var peso = Double.Parse(Peso.Text);

                var icm = (peso / (altura / 100 * altura / 100));
                ICM.Text = icm.ToString();

                string resultado = "";

                if (icm < 18.5)
                {
                    resultado = "Estas bajo de peso";
                }
                else if (icm >= 18.4 && icm <= 24.9)
                {
                    resultado = "Tu peso es normal";
                }
                else if (icm >= 25 && icm <= 29.9)
                {
                    resultado = "Tienes sobrepeso";
                }
                else
                {
                    resultado = "Tienes obesidad, ¡Cuidate!";
                }

                DisplayAlert("Resultado ICM: "+ICM.Text, resultado, "OK");
                Altura.Text = "";
                Peso.Text = "";
                ICM.Text = "";
            }
            else
            {
                DisplayAlert("Datos errones", "Por favor ingresar datos", "OK");
            }

                         
        }
    }
}
