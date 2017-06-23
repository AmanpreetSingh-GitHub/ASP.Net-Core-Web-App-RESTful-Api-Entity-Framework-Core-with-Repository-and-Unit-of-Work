using FrameworkTwo.Model;
using FrameworkTwo.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrameworkTwo.Web.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            RestMessage<List<StudentModel>> response = new RestMessage<List<StudentModel>>();

            try
            {
                ServiceInterface serviceInterface = ServiceInterface.Instance;

                response = await serviceInterface.GetDataAsync<List<StudentModel>>("student");

                if (!response.Success)
                {
                    response.StatusText = "Error fetching Student data";                    
                }
            }
            catch (Exception e)
            {
                response.Exception = e;
                response.SetAsBadRequest();
                response.StatusText = "Error fetching Student data";
            }

            return Json(response);
        }
    }
}