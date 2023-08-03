namespace ProxyDesignPattern
{
    //employeelere internet access temin eden interface
    public interface IInternetAcces 
    {
        public void GrantInternetAccessToEmployyes();
    }


    //mueyyen bir isciye icaze veren class:
    public class EmployeeInternetAccess : IInternetAcces 
    {
        public string EmployeeName { get; set; }
        public EmployeeInternetAccess(string name)
        {
            EmployeeName = name;
        }
        public void GrantInternetAccessToEmployyes()
        {
            Console.WriteLine($"Internet access granted for employee - {EmployeeName}");
        }
    }


    public class ProxyEmployeeInternetAccess : IInternetAcces
    {
        public string EmployeeName { get; set; }
        public EmployeeInternetAccess EmpInternetAccess { get; set; }

        public ProxyEmployeeInternetAccess(string name)
        {
            EmployeeName = name;
        }

        public void GrantInternetAccessToEmployyes()
        {
            if(GetRole(EmployeeName) > 10) // eger vezifesi uygundursa access var
            {
                EmpInternetAccess = new(EmployeeName);
                EmpInternetAccess.GrantInternetAccessToEmployyes();
            }
            else
                Console.WriteLine("No Internet access granted for this role");
        }

        public int GetRole(string name)
        {
            //burda db-den employeenin vezifesi gelmelidi
            return 15;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Client
            string empName = "Siya Cabbarova";
            IInternetAcces internetAcess = new ProxyEmployeeInternetAccess(empName);
            internetAcess.GrantInternetAccessToEmployyes();
        }
    }
}