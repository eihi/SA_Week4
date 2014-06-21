using SA_Week4.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SA_Week4.View
{
    public partial class SodokuView : Window
    {
        SudokuViewModel _sudokuViewModel;

        public SodokuView(SudokuViewModel sudokuViewModel)
        {
            _sudokuViewModel = sudokuViewModel;
            InitializeComponent();
            getGrid();
        }

        public void getGrid()
        {
            SudokuGrid.Children.Clear();

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    int value = _sudokuViewModel.Game.GetSquare(i, j);

                    Label lbl = new Label()
                    {
                        FontSize = 18,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1, 1, 0, 0),
                        HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                        VerticalContentAlignment = System.Windows.VerticalAlignment.Center,

                    };

                    lbl.Content = (value != 0) ? value : lbl.Content = "";

                    if ((i == 3 || i == 6 || i == 9) && (j == 3 || j == 6 || j == 9))
                    {
                        lbl.BorderThickness = new Thickness(1, 1, 1, 1);
                    }
                    else if (i == 3 || i == 6 || i == 9)
                    {
                        lbl.BorderThickness = new Thickness(1, 1, 0, 1);
                    }
                    else if (j == 3 || j == 6 || j == 9)
                    {
                        lbl.BorderThickness = new Thickness(1, 1, 1, 0);
                    }

                    Grid.SetRow(lbl, i - 1);
                    Grid.SetColumn(lbl, j - 1);
                    SudokuGrid.Children.Add(lbl);
                }
            }
        }

        private void btnFillIn_Click(object sender, RoutedEventArgs e)
        {
            bool check = _sudokuViewModel.Game.FillIn(cmbY.SelectedIndex + 1, cmbX.SelectedIndex + 1, cmbValue.SelectedIndex + 1);

            if (check == true)
            {
                getGrid();
            }

            if(_sudokuViewModel.Game.IsFinished()) {
                MessageBox.Show("Game is finished.");
            }
        }

        private void mNewGame_Click(object sender, RoutedEventArgs e)
        {
            _sudokuViewModel.Game.NewGame();
            getGrid();
        }
        
        private void mFinishGame_Click(object sender, RoutedEventArgs e)
        {
            _sudokuViewModel.Game.FinishGame();
            getGrid();
        }
    }
}