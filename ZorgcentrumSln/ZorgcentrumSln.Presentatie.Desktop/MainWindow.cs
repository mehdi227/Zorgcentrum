using System.Collections.ObjectModel;
using System.Windows;
using ZorgcentrumSln.ApplicationServicesProject.Dtos;
using ZorgcentrumSln.ApplicationServicesProject.Services;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Presentatie.Desktop;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private AfspraakService _afspraakService;
    private ObservableCollection<AfspraakDto> _afspraken;

    private const string VoedingsProductType = "Voedingsproduct";
    private const string NietVoedingsProductType = "Niet Voedingsproduct";

    public MainWindow(AfspraakService afspraakService) {
        _afspraakService = afspraakService;

        InitializeComponent();

        _afspraken = new ObservableCollection<AfspraakDto>(_afspraakService.GeefBeschikbareAfspraken());

        //ProductenListView.ItemsSource = _afspraken;

        //ProductTypeComboBox.ItemsSource = new List<String>()
        //{
        //    VoedingsProductType,
        //    NietVoedingsProductType
        //};

        //NutriscoreComboBox.ItemsSource = new List<char>()
        //{
        //    'A', 'B', 'C', 'D', 'E'
        //};

        ResetDetails();
    }

    private void ResetDetails() {
        //OmschrijvingTextBox.Text = String.Empty;
        //PrijsPerStukTextBox.Text = String.Empty;

        //ProductTypeComboBox.SelectedIndex = -1;

        //NutriscoreComboBox.SelectedIndex = -1;
        //KortingspercentageTextBox.Text = String.Empty;

        //NutriscoreStackPanel.Visibility = Visibility.Collapsed;
        //KortingspercentageStackPanel.Visibility = Visibility.Collapsed;
    }

    private void ProductTypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
        //NutriscoreStackPanel.Visibility = Visibility.Collapsed;
        //KortingspercentageStackPanel.Visibility = Visibility.Collapsed;

        //if (ProductTypeComboBox.SelectedIndex >= 0) {
        //    if (ProductTypeComboBox.SelectedItem is string selectedProductType) {
        //        switch (selectedProductType) {
        //            case VoedingsProductType:
        //                NutriscoreStackPanel.Visibility = Visibility.Visible;
        //                break;
        //            case NietVoedingsProductType:
        //                KortingspercentageStackPanel.Visibility = Visibility.Visible;
        //                break;
        //            default:
        //                throw new NotImplementedException();
        //        }
        //    }
        //}
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e) {
        ResetDetails();
    }

    private void VoegToeButton_Click(object sender, RoutedEventArgs e) {
        //if (ProductenListView.SelectedItems.Count > 0) {
        //    MessageBox.Show("Er mag geen product geselecteerd zijn als je een product wil toevoegen.",
        //        "Opmerking", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    return;
        //}

        //if (ProductTypeComboBox.SelectedIndex == -1) {
        //    MessageBox.Show("Gelieve eerste een type te selecteren.",
        //        "Opmerking", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    return;
        //}

        //if (ProductTypeComboBox.SelectedItem is string type) {
        //    Result<AfspraakDto> result;

        //    switch (type) {
        //        case VoedingsProductType:

        //            if (NutriscoreComboBox.SelectedIndex == -1) {
        //                MessageBox.Show("Gelieve eerste een nutriscore te selecteren.",
        //                                "Opmerking", MessageBoxButton.OK, MessageBoxImage.Warning);
        //                return;
        //            }

        //            result = _afspraakService.VoegVoedingsproductToe(
        //                OmschrijvingTextBox.Text,
        //                decimal.Parse(PrijsPerStukTextBox.Text),
        //                (char)NutriscoreComboBox.SelectedItem);
        //            break;

        //        case NietVoedingsProductType:
        //            result = _afspraakService.VoegNietVoedingsProductToe(
        //                OmschrijvingTextBox.Text,
        //                decimal.Parse(PrijsPerStukTextBox.Text),
        //                decimal.Parse(KortingspercentageTextBox.Text));
        //            break;

        //        default: throw new NotImplementedException();
        //    }

        //    if (result.IsFailure) {
        //        MessageBox.Show(String.Join("\n", result.Errors.Select(e => e.Value)),
        //            "Fouten", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //    } else {
        //        _afspraken.Add(result.Value!);
        //    }
        //}
    }

    private void ProductenListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
        //if (ProductenListView.SelectedIndex == -1) {
        //    ResetDetails();
        //    return;
        //}

        //ProductDto geselecteerdProduct = (ProductenListView.SelectedItem as ProductDto)!;

        //OmschrijvingTextBox.Text = geselecteerdProduct.Omschrijving;
        //PrijsPerStukTextBox.Text = geselecteerdProduct.PrijsPerStuk.Bedrag.ToString();

        //switch (geselecteerdProduct) {
        //    case VoedingsProductDto voedingsProductDto:
        //        ProductTypeComboBox.SelectedItem = VoedingsProductType;
        //        NutriscoreComboBox.SelectedItem = voedingsProductDto.Nutriscore;
        //        break;

        //    case NietVoedingsProductDto nietVoedingsProductDto:
        //        ProductTypeComboBox.SelectedItem = NietVoedingsProductType;
        //        KortingspercentageTextBox.Text = nietVoedingsProductDto.Kortingspercentage.Value.ToString();
        //        break;

        //    default: throw new NotImplementedException();
        //}
    }

    private void VerwijderButton_Click(object sender, RoutedEventArgs e) {
        //if (ProductenListView.SelectedIndex == -1) {
        //    MessageBox.Show("Gelieve eerst een product te selecteren.", "Opmerking",
        //        MessageBoxButton.OK, MessageBoxImage.Warning);
        //    return;
        //}

        //if (ProductenListView.SelectedItem is ProductDto geselecteerdeProductDto) {
        //    MessageBoxResult result = MessageBox.Show(
        //        "Wenst u het geselecteerde item te verwijderen?",
        //        "Vraag",
        //        MessageBoxButton.YesNo,
        //        MessageBoxImage.Question);

        //    if (result == MessageBoxResult.Yes) {
        //        Result resultDelete = _afspraakService.VerwijderProduct(geselecteerdeProductDto.Id);

        //        if (resultDelete.IsSuccess) {
        //            _afspraken.Remove(geselecteerdeProductDto);
        //        } else {
        //            MessageBox.Show(String.Join("\n", resultDelete.Errors.Select(e => e.Value)),
        //                    "Fouten", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //        }
        //    }
        //}
    }
}