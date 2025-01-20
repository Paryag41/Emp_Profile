namespace verification_employee.Model
{
    public class VerifyEmploymentRequest
    {

       public string EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string VerificationCode { get; set; }
    }
}
