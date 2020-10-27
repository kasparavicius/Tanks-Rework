using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TankaiServer.Models;
using Classes;

namespace TankaiServer.Controllers
{
    public class TankasController : Controller
    {
        [System.Web.Http.HttpGet]
        public JsonResult GetPlayerList()
        {
            //System.Web.HttpContext.Current.Application.Lock();
            //System.Web.HttpContext.Current.Application["Name"] = "Value";
            //System.Web.HttpContext.Current.Application.UnLock();
            return Json((List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"], JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetEnemyList(string id)
        {
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];
            zaidejai.Find(z => z.getId() == id).updated = true;
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["zaidejai"] = zaidejai;
            System.Web.HttpContext.Current.Application.UnLock();

            return Json(zaidejai.FindAll(z => z.getId() != id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Connect([FromBody] Transportas value)
        {
            string id = GenerateRandomID(24);
            value.setId(id);
            value.updated = false;

            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"] ?? new List<Transportas>();
            zaidejai.Add(value);
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["zaidejai"] = zaidejai;
            System.Web.HttpContext.Current.Application.UnLock();

            return Json(id);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Disconnect([FromBody] Transportas value)
        {
            string msg = "hello";
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];

            zaidejai.RemoveAll(p => p.getId() == value.getId());

            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["zaidejai"] = zaidejai;
            System.Web.HttpContext.Current.Application.UnLock();
            return Json(msg);
        }

        [System.Web.Http.HttpPatch]
        public ActionResult Position([FromBody] Transportas value)
        {
            string msg = "hello";
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];

            zaidejai.Find(z => z.getId() == value.getId()).setPos(value.getPos());
            zaidejai.ForEach(z =>
            {
                if (z.getId() != value.getId())
                {
                    z.updated = false;
                }
            });

            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["zaidejai"] = zaidejai;
            System.Web.HttpContext.Current.Application.UnLock();
            return Json(msg);
        }







        // GET: Tankas
        public ActionResult Index()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

            var filter = Builders<Models.Tankas>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.tanks_collection.Find(filter).ToList();

            return View(result);
        }

        // GET: Tankas/Details/5
        public JsonResult Details(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

            var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.tanks_collection.Find(filter).FirstOrDefault();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult DetailsOfOther(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");
            var filter = Builders<Models.Tankas>.Filter.Ne("_id", id);
            var result = Models.MongoHelper.tanks_collection.Find(filter).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Tankas/Create
        public ActionResult Create()
        {
            return View();
        }

        /*// POST: Tankas/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.tanks_collection =
                    Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

                //Create some _id
                string id = GenerateRandomID(24);

                Models.MongoHelper.tanks_collection.InsertOneAsync(new Models.Tankas { 
                    _id = id,
                    pavadinimas = collection["pavadinimas"],
                    metai = Int32.Parse(collection["metai"]),
                    //pozicija = collection["pozicija"]
                    //pozicijay = Int32.Parse(collection["pozicijay"])
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        private static Random random = new Random();
        private string GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnoprstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s=>s[random.Next(strarray.Length)]).ToArray());
        }

        [System.Web.Http.HttpPost]
        public ActionResult CreateTank([FromBody]Models.Tankas value)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

            string id = GenerateRandomID(24);
            value._id = id;
            Models.MongoHelper.tanks_collection.InsertOneAsync(value);

            return Json(id);
        }

        // GET: Tankas/Edit/5
        public ActionResult Edit(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

            var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.tanks_collection.Find(filter).FirstOrDefault();

            return View(result);
        }

        // POST: Tankas/Edit/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.tanks_collection =
                    Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

                var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);

                var upadate = Builders<Models.Tankas>.Update
                    .Set("pozicijax", Int32.Parse(collection["pozicijax"]))
                    .Set("pozicijay", Int32.Parse(collection["pozicijay"]))
                    .Set("pavadinimas", collection["pavadinimas"])
                    .Set("metai", Int32.Parse(collection["metai"]));
 
                var result = Models.MongoHelper.tanks_collection.UpdateOneAsync(filter, upadate);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Upade locations
        [System.Web.Mvc.HttpPatch]
        public void ChangeLocation(string id, [FromBody] Models.Tankas value)
        {
            /*try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.tanks_collection =
                    Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

                var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);

                var upadate = Builders<Models.Tankas>.Update
                    .Set("pozicija", value.pozicija);
                    //.Set("pavadinimas", collection["pavadinimas"])
                    //.Set("metai", Int32.Parse(collection["metai"]));

                var result = Models.MongoHelper.tanks_collection.UpdateOneAsync(filter, upadate);


                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }*/
        }
        //Json(db.Orders.ToList(), JsonRequestBehavior.AllowGet);

        // GET: Tankas/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.tanks_collection =
                Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

            var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.tanks_collection.Find(filter).FirstOrDefault();

            return View(result);
        }

        // POST: Tankas/Delete/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.tanks_collection =
                    Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

                var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);

                var result = Models.MongoHelper.tanks_collection.DeleteOneAsync(filter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Remove player when closing
        [System.Web.Mvc.HttpDelete]
        public void Remove(string id)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.tanks_collection =
                    Models.MongoHelper.database.GetCollection<Models.Tankas>("tanks");

                var filter = Builders<Models.Tankas>.Filter.Eq("_id", id);

                var result = Models.MongoHelper.tanks_collection.DeleteOneAsync(filter);

            }
            catch
            {

            }
        }
    }
}
