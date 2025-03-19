using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static BusinessLayer.Farmacia;

namespace Admin_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Mostra a data e hora 
            MostrarDataHora();    
            IniciarTimer();
        }
        private FarmaciaCollection Bottles { get; set; }
        private DispatcherTimer timer;


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void InfoCard_Loaded(object sender, RoutedEventArgs e)
        {
            string filter =  " ";
            FarmaciaCollection filterFarmacias = Farmacia.GetListBottles(filter);
            this.card1.Title= "Quantidade Farmacias";
            this.card1.Number = filterFarmacias.Count.ToString();
        }

        private void MostrarDataHora()
        {
            // Atualiza a data e hora
            txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        }

        private void IniciarTimer()
        {
            // Cria o timer para atualizar a hora a cada segundo
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Atualiza a cada segundo
            timer.Tick += (s, e) => MostrarDataHora(); // Atualiza a tela
            timer.Start();
        }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // Aqui você pode adicionar o código que deseja executar quando o dropdown for fechado
            // Por exemplo:
            Console.WriteLine("Dropdown fechado");
        }


    }
}
