using SudokuBasis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuASP.Models
{
    public class Sudoku
    {
        private SudokuModel game;

        public List<string> NewGame()
        {
            game = new SudokuModel();
            game.NewGame();
            return Draw(game);
        }

        public List<string> Draw(SudokuModel game)
        {
            List<string> Values = new List<string>();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    int value = game.GetSquare(x, y);
                    if (value > 0)
                        Values.Add("" + value);
                    else
                        Values.Add("");
                }
            }
            return Values;
        }

        public bool FillInSquare(int x, int y, int value)
        {
            return game.FillIn(x, y, value);
        }

        public List<string> Cheat()
        {
            game.FinishGame();
            return Draw(game);
        }

        public bool Hint(out int x, out int y, out int value)
        {
            int hintPossible;
            game.GetHint(out hintPossible, out x, out y, out value);

            return hintPossible == 1;
         
        }

        public bool IsFinished()
        {
            return game.IsFinished();
        }
    }
}