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
        private static Models.Sudoku sm;

        public static List<string> Values { get; set; }
        public static string Hint { get; set; }
        public ActionResult Index()
        {
            if (sm == null)
                NewGame();
            return View(Create());
        }

        public ActionResult NewGame()
        {
            sm = new Models.Sudoku();
            Values = sm.NewGame();
            Hint = "Show hint";

            return View("Index", Create());
        }

        public ActionResult Cheat()
        {
            Values = sm.Cheat();
            return View("Index", Create());
        }

        public ActionResult FillIn()
        {
            try
            {
                var x = Convert.ToInt32(Request.QueryString["X"]);
                var y = Convert.ToInt32(Request.QueryString["Y"]);
                var value = Convert.ToInt32(Request.QueryString["Value"]);
                var yx = "" + y + x;
                if (sm.FillInSquare(x, y, value))
                {
                    var index = Convert.ToInt32(yx);

                    Values[index] = "" + value;

                    if (sm.IsFinished())
                        ViewBag.Finished = "Congratulations you just finished the game";

                    return View("Index", Create());
                }

                return View("Index", Create());
            }
            catch (Exception)
            {
                return View("Index");
            }
        }

        public ActionResult GetHint()
        {
            int x;
            int y;
            int value;
            if (sm.Hint(out x, out y, out value))
            {
                Hint = String.Format("x: {0}, y: {1}, value: {2}", x, y, value);
                return View("Index", Create());
            }

            return View("Index");
        }

        private Object[] Create()
        {
            return new object[] { Values, Hint };
        }
    }
}
