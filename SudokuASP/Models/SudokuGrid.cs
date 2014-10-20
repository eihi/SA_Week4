using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SudokuASP.Models
{
    public class SudokuGrid
    {
        public DataTable Grid { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}