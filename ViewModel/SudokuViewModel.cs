using SA_Week4.Model;
using System.Windows.Controls;

namespace SA_Week4.ViewModel
{
    public class SudokuViewModel
    {
        private SudokuModel _game;

        public SudokuViewModel()
        {
            _game = new SudokuModel();
            _game.NewGame();
        }

        public SudokuModel Game
        {
            get { return _game; }
        }
    }
}