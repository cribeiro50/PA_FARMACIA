using BusinessLayer;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Admin_Panel
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // Configurar DataContext para o binding funcionar no XAML
            this.DataContext = this;

            MostrarDataHora();
            IniciarTimer();
            CarregarPieChart();
            CarregarBarChart(); 
        }

        private FarmaciaCollection Bottles { get; set; }
        private DispatcherTimer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void InfoCard_Loaded(object sender, RoutedEventArgs e)
        {
            string filter = " ";
            FarmaciaCollection filterFarmacias = Farmacia.GetListBottles(filter) ?? new FarmaciaCollection();

            if (this.card1 != null)
            {
                this.card1.Title = "Quantidade Farmacias";
                this.card1.Number = filterFarmacias.Count.ToString();
            }
        }

        private void MostrarDataHora()
        {
            txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void IniciarTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) => MostrarDataHora();
            timer.Start();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Dropdown fechado");
        }

        // Alterando as propriedades para ChartValues<double>
        public ChartValues<double> ProdutoA { get; set; }
        public ChartValues<double> ProdutoB { get; set; }
        public ChartValues<double> ProdutoC { get; set; }

        private void CarregarPieChart()
        {
            // Inicializando as propriedades com valores
            ProdutoA = new ChartValues<double> { 30 }; // 30% do gráfico
            ProdutoB = new ChartValues<double> { 20 }; // 20% do gráfico
            ProdutoC = new ChartValues<double> { 50 }; // 50% do gráfico
        }

        // Propriedades para o gráfico de barras
        public ChartValues<double> VendasProdutoA { get; set; }
        public ChartValues<double> VendasProdutoB { get; set; }
        public ChartValues<double> VendasProdutoC { get; set; }
        public ChartValues<double> VendasProdutoD { get; set; }
        private void CarregarBarChart()
        {
            // Inicializando os valores fictícios para o gráfico de barras
            VendasProdutoA = new ChartValues<double> { 5000 }; // Vendas do Produto A
            VendasProdutoB = new ChartValues<double> { 7000 }; // Vendas do Produto B
            VendasProdutoC = new ChartValues<double> { 4000 }; // Vendas do Produto C
            VendasProdutoD = new ChartValues<double> { 6000 }; // Vendas do Produto D
        }
    }
}
