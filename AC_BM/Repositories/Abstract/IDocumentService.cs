namespace AC_BM.Repositories.Abstract
{
    public interface IDocumentService
    {
        public Tuple<int, string> SaveDoc(IFormFile docfile);

        public bool DeleteDoc(string DocFileName); 
    }
}
