using AutoMapper;
using ClassLibraryForunversity.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityMVC.Models;

namespace UniversityMVC.Controllers
{
    public class UniversityController : Controller
    {
       
            public readonly IWebHostEnvironment _webHostEnvironment;

            Uri baseAddress = new Uri("https://localhost:7129/api");
            HttpClient client;
            private readonly IMapper _mapper;

            public UniversityController(IMapper mapper)
            {
                client = new HttpClient();
                client.BaseAddress = baseAddress;
                _mapper = mapper;
            }
        public ActionResult Get()
        {


            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Universities/GetUniversitys/").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<University>>(data);
                var unversity = _mapper.Map<List<UniversityModel>>(list);

                return View(unversity);
            }
            else
            {
                return View();
            }

        }

        #region CREATE METHOD

        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region POST METHOD Using Create

        [HttpPost]
        public ActionResult Create(UniversityModel university)
        {
            var postTask = client.PostAsJsonAsync<UniversityModel>(baseAddress + "/Universities/PostUniversity/", university);
            postTask.Wait();
            var result = postTask.Result;


            return RedirectToAction("Get");

        }

        #endregion

        #region UPDATE METHOD
        [HttpGet]
        public ActionResult Update(UniversityModel university)

        {
            return View("Update", university);
        }


        public ActionResult UpdateUnversity(UniversityModel university)
        {
            var putTask = client.PutAsJsonAsync<UniversityModel>(baseAddress + "/Universities/PostUniversity/" + university.Id.ToString(), university);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }
            return View("Update", university);
        }

        #endregion

        #region DELETE METHOD

        public ActionResult Delete(int id)
        {

            //HTTP DELETE
            var deleteTask = client.DeleteAsync(baseAddress + "/Universities/DeleteUniversity/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }

            return RedirectToAction("Delete");
        }
        #endregion


    }
}

