using Microsoft.AspNetCore.Mvc;
using verification_employee.Service;
using verification_employee.Model;

namespace verification_employee.Controllers
{

    [ApiController]
    
    public class VerifyEmploymentController : Controller
    {
        readonly EmploymentVerificationService _employmentVerificationService;

        public VerifyEmploymentController(EmploymentVerificationService employmentVerificationService)
        {
            _employmentVerificationService = employmentVerificationService;
        }


        [Route("api/verify-employment")]
        [HttpPost]
        public IActionResult VerifyEmployment([FromBody] VerifyEmploymentRequest request)
        {
         
            if (request == null || string.IsNullOrWhiteSpace(request.EmployeeId) || string.IsNullOrWhiteSpace(request.CompanyName) || string.IsNullOrWhiteSpace(request.VerificationCode))
            {
                return BadRequest(new VerifyEmploymentResponse
                {
                    IsVerified = false,
                    Message = "Invalid input data."
                });
            }
            bool isVerified = _employmentVerificationService.VerifyEmployment(request.EmployeeId, request.CompanyName, request.VerificationCode);

           
            if (isVerified)
            {
                return Ok(new VerifyEmploymentResponse
                {
                    IsVerified = true,
                    Message = "Employment verified successfully."
                });
            }
            else
            {
                return Unauthorized(new VerifyEmploymentResponse
                {
                    IsVerified = false,
                    Message = "Employment verification failed."
                });
            }
        }


    }
}

