using AC_BM.Repositories.Abstract;
using NuGet.ProjectModel;
using Microsoft.AspNetCore.Mvc;


namespace AC_BM.Repositories.Implementation
{
    public class DocumentService:IDocumentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DocumentService(IWebHostEnvironment webHostEnvironment)
        {
             _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteDoc(string DocFileName)
        {
            try
            {
                var wwwPath = this._webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwPath, "Documents", DocFileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;

                }
                return false;
            }
            catch (Exception )
            {
                return false;
            }
        }

     
        //public Tuple<int, string> SaveDoc(IFormFile docfile)
        //{
        //    try
        //    {
        //        var wwwPath = this._webHostEnvironment.WebRootPath;
        //        var path = Path.Combine(wwwPath, "Documents");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        //confirming if the file is a document
        //        var ext = Path.GetExtension(docfile.FileName);
        //        var allowedExtensions = new string[] { ".docx", ".pdf" };
        //        if (!allowedExtensions.Contains(ext))
        //        {
        //            string message = string.Format("only {0} extensisons are allowed", string.Join(",", allowedExtensions));
        //            return new Tuple<int, string>(0, message);
        //        }
        //        string uniqueString = Guid.NewGuid().ToString();
        //        var newFileName = uniqueString + ext;
        //        var FileWithPath = Path.Combine(path, newFileName);
        //        var stream = new FileStream(FileWithPath, FileMode.Create);
        //        docfile.CopyTo(stream);
        //        stream.Close();
        //        return new Tuple<int, string>(1, newFileName);




        //    }
        //    catch (Exception )
        //    {
        //        return new Tuple<int, string>(0, "Error while saving the attached documents");

        //    }

        //}

        public bool SaveDocument(List<IFormFile> DocFiles)
        {
            try {
                if (DocFiles.Count > 0)
                {
                    foreach (var formFile in DocFiles)
                    {

                       string filename=formFile.FileName; 
                        filename=Path.GetFileName(filename);
                        string uploadpath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Documents" ,filename);    
                    //    if (formFile.Length > 0)
                    //    {

                            //var wwwPath = this._webHostEnvironment.WebRootPath;
                            //var path = Path.Combine(wwwPath, "Documents");
                            //if (!Directory.Exists(path))
                            //{
                            //    Directory.CreateDirectory(path);
                            //}


                            //confirming if the file is a document
                            var ext = Path.GetExtension(filename);
                            var allowedExtensions = new string[] { ".docx", ".pdf" };
                            if (!allowedExtensions.Contains(ext))
                            {
                                string message = string.Format("only {0} extensions are allowed", string.Join(",", allowedExtensions));
                            }
                            string uniqueString = Guid.NewGuid().ToString();
                            var newFileName = uniqueString + ext;
                            var FileWithPath = Path.Combine(uploadpath);
                            var stream = new FileStream(FileWithPath, FileMode.Create);
                            formFile.CopyToAsync(stream);
                           // stream.Close();
                           
                       // }


                    }
                }
                return true;
            }
            catch(Exception ex)
            {
               // ViewBag.Message = "Error while saving the document";
                return false;
            }
                }

       
    }
}
