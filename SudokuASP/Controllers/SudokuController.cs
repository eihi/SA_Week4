using SudokuASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SudokuASP.Controllers
{
    public class SudokuController : Controller
    {
        public ActionResult Index()
        {
            SudokuGrid grid = new SudokuGrid();
            DataTable tb = new DataTable();
            for (int i = 0; i < 9; i++)
                tb.Columns.Add();
            for (int i = 0; i < 9; i++)
                tb.Rows.Add();

            grid.Grid = tb;
            grid.Rows = 9;
            grid.Columns = 9;
            return View(grid);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult NewGame()
        {

            return View();
        }
    }
}
