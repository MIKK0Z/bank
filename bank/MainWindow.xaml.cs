using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bank;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private float balance;
    private float wplat;
    private float wyplat;
    public MainWindow()
    {
        InitializeComponent();

    }

    private void ButtonWplac_OnClick(object sender, RoutedEventArgs e)
    {
        string value = TextBox.Text;
        TextBox.Text = "";

        float fvalue = float.Parse(value);
        
        balance += fvalue;
        LabelBalance.Content = balance.ToString("C", new CultureInfo("pl-PL"));
        
        wplat += fvalue;
        LabelWplaty.Content = wplat.ToString("C", new CultureInfo("pl-PL"));

        LabelMsg.Content = "dokonano wplaty: " + fvalue.ToString("C", new CultureInfo("pl-PL"));
    }

    private void ButtonWyplac_OnClick(object sender, RoutedEventArgs e)
    {
        string value = TextBox.Text;
        TextBox.Text = "";

        float fvalue = float.Parse(value);

        if (fvalue > balance)
        {
            LabelMsg.Content = "nie udalo sie zrealizowac tej operacji";
            return;
        }

        balance -= fvalue;
        LabelBalance.Content = balance.ToString("C", new CultureInfo("pl-PL"));

        wyplat += fvalue;
        LabelWyplaty.Content = wyplat.ToString("C", new CultureInfo("pl-PL"));
        
        LabelMsg.Content = "dokonano wyplaty: " + fvalue.ToString("C", new CultureInfo("pl-PL"));
    }

    private void ButtonWyplacAll_OnClick(object sender, RoutedEventArgs e)
    {
        float fvalue = balance;

        balance = 0;
        LabelBalance.Content = balance.ToString("C", new CultureInfo("pl-PL"));
        
        wyplat += fvalue;
        LabelWyplaty.Content = wyplat.ToString("C", new CultureInfo("pl-PL"));

        LabelMsg.Content = "dokonano wyplaty: " + fvalue.ToString("C", new CultureInfo("pl-PL"));
    }
}