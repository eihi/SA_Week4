﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBasis
{
    public class SudokuModel
    {
        public const int TOTAL_NUMBER_OF_SQUARES = 81;
        public const int COLUMN_SIZE = 9;
        public const int ROW_SIZE = 9;

        private Sudoku.IGame game;
        private int _filledInSquares;

        public SudokuModel()
        {
            game = new Sudoku.Game();
        }

        public void NewGame()
        {
            game.create();
            FilledInSquares = 0;
            CountFilledInSquares();
        }

        public int FilledInSquares
        {
            get { return _filledInSquares; }
            private set { _filledInSquares = value; }
        }

        private int CountFilledInSquares()
        {
            int number = 0;

            for (int i = 1; i < ROW_SIZE + 1; i++)
            {
                for (int j = 1; j < COLUMN_SIZE + 1; j++)
                {
                    if (GetSquare(i, j) != 0)
                    {
                        FilledInSquares++;
                    }
                }
            }

            return number;
        }

        public bool FillIn(int x, int y, int value)
        {
            if (SetSquare(x, y, value) != 0)
            {
                FilledInSquares++;
                return true;
            }

            return false;
        }

        public int GetSquare(int x, int y)
        {
            int value = 0;
            game.get(x, y, out value);
            return value;
        }

        private int SetSquare(int x, int y, int value)
        {
            int canAdapt = 0;
            game.set(x, y, value, out canAdapt);

            return canAdapt;
        }

        public void GetHint(out int hintPossible, out int x, out int y, out int value)
        {
            game.hint(out hintPossible, out x, out y, out value);
        }

        public void FinishGame()
        {
            for (int i = FilledInSquares; i < TOTAL_NUMBER_OF_SQUARES - 2; i++)
            {
                int hintPossible, x, y, value;
                game.hint(out hintPossible, out x, out y, out value);
                FillIn(x, y, value);
            }
        }

        public bool IsFinished()
        {
            bool finished = false;
            if (FilledInSquares == TOTAL_NUMBER_OF_SQUARES)
            {
                int valid;
                game.isValid(out valid);
                if (valid == 1)
                    finished = true;
            }
            return finished;
        }
    }
}
