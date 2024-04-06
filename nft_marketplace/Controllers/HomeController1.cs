using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using nft_marketplace.DATA;
using nft_marketplace.Models;
using NuGet.Protocol.Plugins;

namespace nft_marketplace.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=nft_marketplace;Integrated Security=True;Connect Timeout=30;Encrypt=False;MultiSubnetFailover=False";

        contact empObj = new contact();
        public IActionResult Index()
        {
            empObj = new contact();
            List<contact> lst = empObj.getData();// fetches all the records
            return View(lst);

        }
        

        public IActionResult home()
        {
            return View();
        }

        [HttpPost]

        public IActionResult home(contact emp)
        {
            bool res;

            if (ModelState.IsValid)
            {
                empObj=new contact();
                res = empObj.insert(emp); // Assuming insert(Contact emp) inserts data into the database
                if (res)
                {
                    return RedirectToAction("Home2");   
                }
                else
                {
                    TempData["msg"] = "Not Added. Something went wrong..!!";
                }
            }
            return View();
        }


        public IActionResult Home2()
        {
            return View();
        }

        public IActionResult Market()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(createBid user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        string sql = "INSERT INTO CreateBid (price, minBid, startDate, expDate, title, description) VALUES (@price, @minBid, @startDate, @expDate, @title, @description)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@price", user.price);
                            command.Parameters.AddWithValue("@minBid", user.minBid);
                            command.Parameters.AddWithValue("@startDate", user.startDate);
                            command.Parameters.AddWithValue("@expDate", user.expDate);
                            command.Parameters.AddWithValue("@title", user.title);
                            command.Parameters.AddWithValue("@description", user.description);

                            command.ExecuteNonQuery();
                        }
                    }


                    ViewBag.Message = "Congratulations! Your BID has been added successfully";
                    TempData["AlertMessage"] = "Your BID has been added successfully";
                    return RedirectToAction("Home2");
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = "An error occurred while adding the bid: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Please fill in all required fields";
            }

            return View(user);
        }

        public IActionResult Contact()
        {
            return View();
        }

       

        public IActionResult Wallet()
        {
            return View();
        }

    }
}
