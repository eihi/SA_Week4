using SudokuWPF.MVVM;
using SudokuBasis;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuWPF.ViewModel
{
    public class SudokuViewModel : PropertyChangedBase
    {
        private readonly RelayCommand setValueCommand;
        private readonly RelayCommand hintCommand;
        private readonly RelayCommand newGameCommand;
        private readonly RelayCommand finishGameCommand;

        private Grid grid;
        public Grid Grid
        {
            get { return grid; }
            set
            {
                grid = value;
                OnPropertyChanged("Grid");
            }
        }

        private SudokuModel game;

        public SudokuViewModel()
        {
            game = new SudokuModel();

            CreateGrid();

            this.setValueCommand = new RelayCommand(SetValue);
            this.hintCommand = new RelayCommand(Hint);
            this.newGameCommand = new RelayCommand(NewGame);
            this.finishGameCommand = new RelayCommand(FinishGame);

            game.NewGame();
            GetGrid();
        }

        private void FinishGame(object obj)
        {
            game.FinishGame();
            GetGrid();
        }

        private void NewGame(object obj)
        {
            game.NewGame();
            GetGrid();
        }

        private void CreateGrid()
        {
            grid = new Grid();

            grid.Height = 450;
            grid.Width = 450;

            for (int i = 0; i < 9; i++)
            {
                ColumnDefinition c = new ColumnDefinition() { Width = new System.Windows.GridLength(50) };
                grid.ColumnDefinitions.Add(c);
            }

            for (int j = 0; j < 9; j++)
            {
                RowDefinition r = new RowDefinition() { Height = new System.Windows.GridLength(50) };
                grid.RowDefinitions.Add(r);
            }
        }

        public RelayCommand SetValueCommand { get { return setValueCommand; } }
        public RelayCommand HintCommand { get { return hintCommand; } }
        public RelayCommand NewGameCommand { get { return newGameCommand; } }
        public RelayCommand FinishGameCommand { get { return finishGameCommand; } }

        private void Hint(object obj)
        {
            int hintPossible;
            int y;
            int x;
            int value;
            game.GetHint(out hintPossible, out x, out y, out value);

            if (hintPossible == 1)
            {
                XAxis = x;
                YAxis = y;
                PutValue = value;
            }
        }

        private void SetValue(object obj)
        {
            bool check = game.FillIn(YAxis, XAxis, PutValue);

            if (check == true)
                GetGrid();

            if (game.IsFinished())
                MessageBox.Show("Congratulations you just finished the game", "Game finished!");
        }

        public SudokuModel Game
        {
            get { return game; }
        }

        private void GetGrid()
        {
            Grid.Children.Clear();

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    int value = game.GetSquare(i, j);

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
                        lbl.BorderThickness = new Thickness(1, 1, 1, 1);
                    else if (i == 3 || i == 6 || i == 9)
                        lbl.BorderThickness = new Thickness(1, 1, 0, 1);
                    else if (j == 3 || j == 6 || j == 9)
                        lbl.BorderThickness = new Thickness(1, 1, 1, 0);

                    Grid.SetRow(lbl, i - 1);
                    Grid.SetColumn(lbl, j - 1);
                    Grid.Children.Add(lbl);
                }
            }
        }

        #region Properties
        private int xAxis;
        public int XAxis
        {
            get { return xAxis; }
            set
            {
                xAxis = value;
                OnPropertyChanged("XAxis");
            }
        }

        private int yAxis;
        public int YAxis
        {
            get { return yAxis; }
            set
            {
                yAxis = value;
                OnPropertyChanged("YAxis");
            }
        }

        private int putValue;
        public int PutValue
        {
            get { return putValue; }
            set
            {
                putValue = value;
                OnPropertyChanged("PutValue");
            }
        }
        #endregion
    }
}