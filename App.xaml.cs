using SudokuWPF.View;
using SudokuWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SudokuWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SudokuView sudokuView = new SudokuView();
            SudokuViewModel sudokuViewModel = new SudokuViewModel();
            sudokuView.DataContext = sudokuViewModel;

            sudokuView.Show();
        }
    }
}