using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cars;

namespace WebUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Create Cars database...
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
                InsertData();

                //Create access to Cars database...
                var db = new CarDb();
                //db.Database.Log = Console.WriteLine;

                //Populate Make drop-down...



                //Populate Model drop-down...



                //Populate Automobiles Grid View...
                var query =
                    from car in db.Cars
                    group car by car.Manufacturer into manufacturer
                    select new
                    {
                        Name = manufacturer.Key,
                        Cars = (from car in manufacturer
                                orderby car.Combined descending
                                select car).Take(2)
                    };

                gvAutomobiles.DataSource = query.ToList();
                gvAutomobiles.DataBind();
            }
        }

        public static void InsertData()
        {
            var cars = ProcessCars(@"E:\GitHub\linqsamples\WebUI\Data\fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }
    }
}