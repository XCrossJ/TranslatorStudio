using OnlineTranslatorStudio.Models;
using OnlineTranslatorStudio.Utilities;
using System;
using System.IO;
using System.Web.Mvc;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Repository;

namespace OnlineTranslatorStudio.Controllers
{
    public class StudioController : Controller
    {
        //https://stackoverflow.com/questions/25151542/get-romaji-from-google-translation-website
        // GET: Studio
        public ActionResult Index()
        {
            return View();
        }

        //http://www.binaryintellect.net/articles/c69d78a3-21d7-416b-9d10-6b812a862778.aspx
        // POST: Studio/Dashboard
        [HttpPost]
        public ActionResult Dashboard(OnlineTranslationRequest translationRequest, string submit)
        {
            TranslationData data = new TranslationData();

            switch (submit)
            {
                case "Open":
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file != null & file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var fileType = Path.GetExtension(fileName);
                            var filePath = @"C:\Temp\" + fileName;
                            file.SaveAs(filePath);

                            if (fileType == ".txt")
                                data = FileHelper.OpenTextFile(filePath, fileName);
                            if (fileType == ".tsp")
                                data = FileHelper.OpenTSPFile(filePath, fileName);
                        }
                    }
                    else
                    {
                        throw new Exception("No requests.");
                    }

                    break;
                case "Create":

                    if (translationRequest != null)
                    {
                        string fileName = translationRequest.ProjectName;
                        string[] rawData = translationRequest.RawData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        ProjectData project = new ProjectDataRepository().CreateProjectDataFromArray(fileName, rawData);
                        data = new TranslationDataRepository().CreateTranslationDataFromProject(project);
                    }
                    else
                    {
                        throw new Exception("No requests.");
                    }

                    break;
                default:
                    break;
            }

            if (data.NumberOfLines != 0)
                ViewBag.percentage = data.NumberOfCompletedLines * 100 / data.NumberOfLines;
            else
                ViewBag.percentage = 0;
            return View(data);
            
        }

        public ActionResult Desk()
        {
            var file = Request.Files[0];
            TranslationData data = new TranslationData();
            if (file != null & file.ContentLength > 0)
            {
                var filePath = file.FileName;
                var fileName = Path.GetFileName(filePath);
                var fileType = Path.GetExtension(filePath);

                if (fileType == ".txt")
                    data = FileHelper.OpenTextFile(filePath, fileName);
                if (fileType == ".tsp")
                    data = FileHelper.OpenTSPFile(filePath, fileName);
            }
            if (data.NumberOfLines != 0)
                ViewBag.percentage = data.NumberOfCompletedLines * 100 / data.NumberOfLines;
            else
                ViewBag.percentage = 0;
            return View(data);
        }

        // GET: Studio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Studio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Studio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Studio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
