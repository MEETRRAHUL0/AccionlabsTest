using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace accionlabsTest
{
   public delegate bool EmpById(Employe emp);

    public class Test4_HttpPatchVerb : ApiController
    {
        //4) Write API method with HttpPatch Verb, used for Partial Object Update
        List<Employe> empList;
        public Test4_HttpPatchVerb()
        {
            empList = new List<Employe>()
            {
                new Employe{Id = 1 ,  name = "test"},
                new Employe { Id = 1, name = "test" }
            };
        }
        [HttpPatch]
        public IEnumerable<Employe> UpdateName(int id , [FromUri]string name)
        {
            empList.Find(e => e.Id == id).name = name;
            return empList;
        }

        [HttpGet]
        public IEnumerable<Employe> GetAll()
        {
            return empList;
        }

        [HttpGet]
        public IEnumerable<Employe> GetByID(List<Employe> empList, EmpById empById)
        {
            return empList.Where(w => empById(w));
        }
    }

    public class Employe
    {
        public int Id { get; set; }
        public string name { get; set; }

    }
}
