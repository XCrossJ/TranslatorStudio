using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineTranslatorStudio.Attributes;
using OnlineTranslatorStudio.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Factory;
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
        //
        // Consult below for new file implementation
        //https://www.aurigma.com/upload-suite/developers/aspnet-mvc/how-to-upload-files-in-aspnet-mvc
        //https://docs.microsoft.com/en-us/aspnet/web-pages/overview/data/working-with-files
        // POST: Studio/Dashboard
        [HttpPost]
        public ActionResult Dashboard(OnlineTranslationRequest translationRequest, string submit)
        {
            ITranslationData data = null;
            IProjectDataFactory projectDataFactory = new ProjectDataFactory();
            ISubTranslationDataFactory subTranslationDataFactory = new SubTranslationDataFactory();
            ITranslationDataFactory translationDataFactory = new TranslationDataFactory(projectDataFactory, subTranslationDataFactory);
            IFileRepository fileRepository = new FileRepository(translationDataFactory);

            switch (submit)
            {
                case "Open":

                    if (Request.Files.Count > 0 && Request.Files[0].FileName.Any())
                    {
                        var file = Request.Files[0];
                        if (file != null & file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var fileType = Path.GetExtension(fileName);
                            // Need to treat this at some point
                            var filePath = @"C:\Temp\" + fileName;
                            file.SaveAs(filePath);

                            var openData = fileRepository.OpenFile(fileType, filePath, fileName);
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
                        IProjectData project = projectDataFactory.CreateProjectDataFromArray(fileName, rawData);
                        data = translationDataFactory.CreateTranslationDataFromProject(project);
                    }
                    else
                    {
                        throw new Exception("No requests.");
                    }

                    break;

                default:
                    break;
            }
            
            System.Web.HttpContext.Current.Session["ProjectData"] = data.GetProjectData();
            return View();
            
        }

        [HttpPost]
        public JsonResult OpenProject()
        {
            var data = System.Web.HttpContext.Current.Session["ProjectData"];
            var response = Json(data);
            return response;
        }

        [HttpPost]
        public JsonResult SaveProject(OnlineProjectData data)
        {
            var project = data.MapToProjectData();
            var success = true;
            var errorMessage = "";
            try
            {
                System.Web.HttpContext.Current.Session["ProjectData"] = project;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                success = false;
            }
            var response = Json(new { success, errorMessage });
            return response;
        }

        [HttpPost]
        public JsonResult CreateProjectFile(OnlineProjectData data)
        {
            //https://www.codeproject.com/Tips/1156485/How-to-Create-and-Download-File-with-Ajax-in-ASP-N

            var project = data.MapToProjectData();
            var saveString = project.GetSaveString();
            var json = JObject.Parse(saveString);

            var fileName = $@"{data.ProjectName}.tsp";

            var errorMessage = "";

            try
            {
                //save the file to server temp folder
                string fullPath = Path.Combine(Server.MapPath("~/temp"), fileName);

                FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonWriter.Formatting = Formatting.Indented;
                        json.WriteTo(jsonWriter);
                    }
                }
                file.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //return the Excel file name
            var response = Json(new { fileName, errorMessage });
            return response;
        }

        [HttpPost]
        public JsonResult CreateExportFile(OnlineProjectData data)
        {
            //https://www.codeproject.com/Tips/1156485/How-to-Create-and-Download-File-with-Ajax-in-ASP-N

            var fileName = $@"{data.ProjectName}.txt";

            var errorMessage = "";

            try
            {
                //save the file to server temp folder
                string fullPath = Path.Combine(Server.MapPath("~/temp"), fileName);

                FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    foreach (var line in data.ProjectLines)
                    {
                        streamWriter.WriteLine(line.Translation);
                    }
                }
                file.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //return the Excel file name
            var response = Json(new { fileName, errorMessage });
            return response;
        }

        [HttpGet]
        [DeleteFile] //Action Filter, it will auto delete the file after download, 
        public ActionResult DownloadFile(string file)
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
