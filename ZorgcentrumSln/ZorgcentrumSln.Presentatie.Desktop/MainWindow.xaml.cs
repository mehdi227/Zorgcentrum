using System.Collections.ObjectModel;
using System.Windows;
using ZorgcentrumSln.ApplicationServicesProject.Services;
using ZorgcentrumSln.ApplicationServicesProject.Dtos;

namespace ZorgcentrumSln.Presentatie.Desktop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private AfspraakService _afspraakService;
        private ObservableCollection<AfspraakDto> _afspraken;

        private const string ConsultatieType = "Consultatie";
        private const string OperatieType = "Operatie";
        private const string ControleType = "Controle";

        public MainWindow(AfspraakService afspraakService) {
            _afspraakService = afspraakService;

            InitializeComponent();

            _afspraken = new ObservableCollection<AfspraakDto>(_afspraakService.GeefBeschikbareAfspraken());

            AfspraakListView.ItemsSource = _afspraken;

            AfspraakTypeComboBox.ItemsSource = new List<String>() {
            ConsultatieType,
            OperatieType,
            ControleType
        };

            ResetDetails();
        }
    }
}