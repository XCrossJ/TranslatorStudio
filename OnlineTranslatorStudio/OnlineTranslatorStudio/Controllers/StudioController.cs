﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineTranslatorStudio.Attributes;
using OnlineTranslatorStudio.Models;
using System;
using System.IO;
using System.Web.Mvc;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;

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
            ITranslationData data = new TranslationData();

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
                            // Need to treat this at some point
                            var filePath = @"C:\Temp\" + fileName;
                            file.SaveAs(filePath);

                            var openData = FileHelper.OpenHandler(fileType, filePath, fileName);
                            data = openData.Item1;
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
                        IProjectData project = new ProjectDataRepository().CreateProjectDataFromArray(fileName, rawData);

                        for (int i = 0; i < project.TranslatedLines.Count; i++)
                        {
                            project.TranslatedLines[i] = string.Empty;
                        }
                        
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
            System.Web.HttpContext.Current.Session["ProjectData"] = data.GetProjectData();
            return View(data);
            
        }

        public ActionResult Desk()
        {
            var file = Request.Files[0];
            ITranslationData data = new TranslationData();
            if (file != null & file.ContentLength > 0)
            {
                var filePath = file.FileName;
                var fileName = Path.GetFileName(filePath);
                var fileType = Path.GetExtension(filePath);

                var openData = FileHelper.OpenHandler(fileType, filePath, fileName);
                data = openData.Item1;
            }
            if (data.NumberOfLines != 0)
                ViewBag.percentage = data.NumberOfCompletedLines * 100 / data.NumberOfLines;
            else
                ViewBag.percentage = 0;
            return View(data);
        }

        [HttpPost]
        public JsonResult OpenProject()
        {
            var data = System.Web.HttpContext.Current.Session["ProjectData"];
            var response = Json(data);
            return response;
        }

        [HttpPost]
        public JsonResult ExportProject(ProjectData data)
        {
            //https://www.codeproject.com/Tips/1156485/How-to-Create-and-Download-File-with-Ajax-in-ASP-N

            var saveString = data.GetSaveString();
            var json = JObject.Parse(saveString);

            var fileName = $@"{data.ProjectName}.tsp";

            //save the file to server temp folder
            string fullPath = Path.Combine(Server.MapPath("~/temp"), fileName);

            FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    json.WriteTo(jsonWriter);
                }
            }
            file.Close();

            //var errorMessage = "you can return the errors in here!";

            //return the Excel file name
            var response = Json(new { fileName = fileName, errorMessage = "" });
            return response;
        }

        [HttpGet]
        [DeleteFile] //Action Filter, it will auto delete the file after download, 
        public ActionResult DownloadProject(string file)
        {
            //get the temp folder and file path in server
            string fullPath = Path.Combine(Server.MapPath("~/temp"), file);

            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"
            return File(fullPath, "text/plain", file);
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
