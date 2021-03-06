﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using static JSONtestWebsite.Models.UserModel;

namespace JSONtestWebsite.Controllers
{
    public class UsersController : Controller
    {
        //GET: Users
        public async Task<ActionResult> Index()
        {
            List<User> UserInfo = new List<User>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();

                //Define request data format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

                //Check response sucessful
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(Response);

                }
                //Return the User list to view
                return View(UserInfo);
            }
        }

        //Update

        //Delete
    }
}