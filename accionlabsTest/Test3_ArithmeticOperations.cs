using System.Collections.Generic;
using System.Linq;

namespace accionlabsTest
{
    public delegate bool GetById(Emp emp);
    public delegate int Calculation(int n1, int n2);

    public static class Test3_ArithmeticOperations
    {
        //3) C# Program Implements Arithmetic Operations using Delegates

 
        public static int Add (int n1, int n2)
        {
            return n1 + n2;
        }
        public static int Sub(int n1, int n2)
        {
            return n1 - n2;
        }
        public static int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public static int Divide(int n1, int n2)
        {
            return n1 / n2;
        }
    }


    public class Test3_Deligate
    {
        public readonly List<Emp> empList;
        public Test3_Deligate()
        {
            empList = new List<Emp>()
            {
                new Emp { Id = 1, Name = "test1"},
                new Emp { Id = 2, Name = "test2" }
            };
        }

        public List<Emp> GetAll()
        {
            return empList;
        }

        public static IEnumerable<Emp> Search(List<Emp> empList, GetById empById)
        {
            return empList.Where(w => empById(w));
        }
    }

    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
