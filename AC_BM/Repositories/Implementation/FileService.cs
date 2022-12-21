using AC_BM.Repositories.Abstract;

namespace AC_BM.Repositories.Implementation
{
    public class FileService:IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
             _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteImage(string ImageFileName)
        {
            try
            {
                var wwwPath = this._webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\",ImageFileName);
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

        public Tuple<int, string> SaveImage(IFormFile imagefile)
        {
                try
            {
                var wwwPath = this._webHostEnvironment.WebRootPath;
                var path=Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //confirming if the file is an image
                var ext=Path.GetExtension(imagefile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string message = string.Format("only {0} extensisons are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int,string>(0,message);    
                }
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var FileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(FileWithPath, FileMode.Create);
                imagefile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);




            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error while uploading the file");

            }



        }
    }
}
