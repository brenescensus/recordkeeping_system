using AC_BM.Models;

namespace AC_BM.Helper
{
    public static class Services
    {
        public static List<Service> GetAll()
        {
            return new List<Service>
            {
                new Service() { Name = "Immigration", Id = "mediation" },
                new Service() { Name = "Mediation", Id = "immigration" },
                new Service() { Name = "Tax", Id = "tax" },
                new Service() { Name = "Citizenship By Investment", Id = "citizenship" },
                new Service() { Name = "Corporate Services", Id = "corporate" },
                new Service() { Name = "Research And Development", Id = "research" },
                 new Service() { Name = "Legal Services", Id = "legal" },
                  new Service(){ Name = "Business Planning and Strategy", Id = "business" },
            };
        }
    }
}
