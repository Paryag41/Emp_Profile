using Employement_Verification_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Employement_Verification_UI
{
    public class EmployeeVerficationController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeVerficationController(IConfiguration configuration)
        {
            
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Verify()
        {
            var model = new EmploymentVerificationModel();  // initialize model if necessary

            return View(model);
        }

        // POST: Employment/Verify
        [HttpPost]
        public async Task<IActionResult> Verify(EmploymentVerificationModel model)
        {
            if (ModelState.IsValid)
            {
                // Call the API to verify employment
                var isVerified = await VerifyEmploymentAsync(model);

                if (isVerified)
                {
                    ViewBag.Message = " Verified";
                }
                else
                {
                    ViewBag.Message = "Not Verified ";
                }
            }
            else
            {
                ViewBag.Message = "Please fill in all fields correctly.";
            }

            return View(model);
        }

        private async Task<bool> VerifyEmploymentAsync(EmploymentVerificationModel model)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var LinkApi = _configuration.GetConnectionString("apiUri");

            var response = await client.PostAsync(LinkApi,content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var verificationResult = JsonConvert.DeserializeObject<VerifyEmploymentResponse>(responseContent);
                return verificationResult.IsVerified;
            }

            return false;
        }
    }

    public class VerifyEmploymentResponse
    {
        public bool IsVerified { get; set; }
        public string Message { get; set; }
    }
}

