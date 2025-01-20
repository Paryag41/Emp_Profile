
*********************************************************************************************************************
Steps to setup : 
1.Host the API in the IIS, by pasting the publish folder in the WWROOT Directory
path : \API\verification_employee\bin\Release\net6.0\publish.

2.Then edit the appsettings.json file with the updated api url in tag "apiUri"  as shown below,
 "apiUri": "https://localhost:7113/api/verify-employment" in the publish folder of the Employee_verification_UI publish folder
 path :Employee_Verification_UI\Employement_Verification_UI\bin\Release\net6.0\publish
 
3.Host the  Employee_verification_UI website in the IIS with default app pool.

4.sample data to check the verification of he employee. 

Sample Data : { EmployeeId = "12345", CompanyName = "Acme Corp", VerificationCode = "validCode123" } ,{ EmployeeId = "67890", CompanyName = "Tech Innovations", VerificationCode = "secureCode456" }, { EmployeeId = "11121", CompanyName = "Global Enterprises", VerificationCode = "companyCode789" }


*********************************************************************************************************************
Assumptions : All fields are required to validate the employee

.Employee ID (numeric)
▪ Company name (text)
▪ Verification code (text)

*********************************************************************************************************************
Approach :

Empoyee verifcation is done on the api end point where predefined data in the memory is set.
method with post attribute is set in the api controller with employee model with the employee values from the body of the request which was send to the api,
 message model is used to set the message and code which was send as a respoonse to the other service.

UI is made in dot net core 6 same as the api is build in the dot net core 6 , 
UI consists of the form which consists of the three fields containing the 
employeeid , companyName , Verifcationcode 

when the user click on the verifcation button on the form , then post request is sent in the UI controller, with the employee filds set, then these employee details are sent 
to the api post method for further verifcation, after the api send back a response, which is displayed on the UI of the form in accordance of the response, red danger message or info message 
is shown on the screen.  