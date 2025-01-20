using verification_employee.Model;

namespace verification_employee.MemorySampleDt
{
    public class InMemoryEmployeeDataStore
    {
    
        private static List<Employee> _employees = new List<Employee>();
    public void AddEmployee()
        {
            _employees.Add(new Employee
            {
                EmployeeId = "12345",
                CompanyName = "Acme Corp",
                VerificationCode = "validCode123"
            });

            _employees.Add(new Employee
            {
                EmployeeId = "67890",
                CompanyName = "Tech Innovations",
                VerificationCode = "secureCode456"
            });
            _employees.Add(new Employee
            {
                EmployeeId = "11121",
                CompanyName = "Global Enterprises",
                VerificationCode = "companyCode789"
            });
        }

        
        public Employee GetEmployeeById(string employeeId)
        {
            if (_employees.Count==0)
            {
                AddEmployee();
            }

            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}
