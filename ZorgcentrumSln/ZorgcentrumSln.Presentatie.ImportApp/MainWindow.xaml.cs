using Microsoft.Win32;
using System.Windows;

namespace ZorgcentrumSln.Presentatie.ImportApp; 
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }
    private void BestandInlezen_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog {
            Filter = "CSV-bestanden (*.csv)|*.csv",
            Title = "Selecteer een CSV-bestand"
        };

        if (openFileDialog.ShowDialog() == true) {
            string bestandPad = openFileDialog.FileName;
        }

        //Use case VoegIngelezenBestand toe aan correcte Repository
    }
}