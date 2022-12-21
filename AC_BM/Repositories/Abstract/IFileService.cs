namespace AC_BM.Repositories.Abstract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imagefile);

        public bool DeleteImage(string ImageFileName); 
    }
}
