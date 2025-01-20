using verification_employee.MemorySampleDt;

namespace verification_employee.Service
{
    public class EmploymentVerificationService
    {
        private readonly InMemoryEmployeeDataStore _employeeDataStore;

        public EmploymentVerificationService(InMemoryEmployeeDataStore employeeDataStore)
        {
            _employeeDataStore = employeeDataStore;
        }

        // Check if the employee exists
        public bool EmployeeExists(string employeeId)
        {
            var employee = _employeeDataStore.GetEmployeeById(employeeId);
            return employee != null;
        }

        // verification code is correct
        public bool IsVerificationCodeValid(string verificationCode, string employeeId)
        {
            var employee = _employeeDataStore.GetEmployeeById(employeeId);
            return employee?.VerificationCode == verificationCode;
        }

        // verify employment using employeeId, companyName, and verificationCode
        public bool VerifyEmployment(string employeeId, string companyName, string verificationCode)
        {
            var employee = _employeeDataStore.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return false;  
            }

            if (employee.CompanyName != companyName)
            {
                return false;  
            }

            if (employee.VerificationCode != verificationCode)
            {
                return false;  
            }

            return true;  
        }
    }
}
