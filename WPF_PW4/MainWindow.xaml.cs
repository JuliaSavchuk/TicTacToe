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

namespace WPF_PW4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            int cellIndex = Convert.ToInt32(pressedButton.Tag);

            if (Game.IsTaken(cellIndex))
                return;

            Game.Turn(cellIndex);

            pressedButton.Content = Game.CurrentPlayer;

            char? winner = Game.GetWinner();

            if ((winner) != null)
            {
                MessageBox.Show($"Player '{winner}' winner!");
                Application.Current.Shutdown();
            }
            else if (Game.IsTie())
            {
                MessageBox.Show("It's a tie!");
                Application.Current.Shutdown();
            }
            else
            {
                Game.ChangePlayer();
            }
        }
    }
}