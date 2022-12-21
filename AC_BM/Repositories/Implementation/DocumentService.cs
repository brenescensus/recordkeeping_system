using AC_BM.Repositories.Abstract;

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
            catch (Exception ex)
            {
                return false;
            }
        }

     
        public Tuple<int, string> SaveDoc(IFormFile docfile)
        {
            try
            {
                var wwwPath = this._webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwPath, "Documents");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //confirming if the file is an image
                var ext = Path.GetExtension(docfile.FileName);
                var allowedExtensions = new string[] { ".docx", ".pdf" };
                if (!allowedExtensions.Contains(ext))
                {
                    string message = string.Format("only {0} extensisons are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, message);
                }
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var FileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(FileWithPath, FileMode.Create);
                docfile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);




            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error while saving the attached documents");

            }

        }

              



        
    }
}
