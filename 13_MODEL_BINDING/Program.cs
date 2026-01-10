/*******************************************************
 * MODEL BINDING & VALIDATION — ASP.NET Core 9
 * -----------------------------------------------------
 * This tutorial explains:
 * 1. What Model Binding is
 * 2. How ASP.NET Core automatically binds data
 * 3. What Validation is
 * 4. How to use Data Annotations
 * 5. How to handle validation in controllers
 * 6. How to return errors to the client
 *******************************************************/


/*******************************************************
 * 1. WHAT IS MODEL BINDING?
 * -----------------------------------------------------
 * Model Binding automatically maps incoming data from:
 *  - JSON body
 *  - Query string
 *  - Route parameters
 *  - Form data
 *
 * …into C# objects or method parameters.
 *
 * Example:
 *   POST /users
 *   { "name": "Nour", "age": 22 }
 *
 * ASP.NET Core binds this JSON to a C# object:
 *
 *   public IActionResult CreateUser(UserModel model)
 *
 *******************************************************/


/*******************************************************
 * 2. SIMPLE MODEL CLASS (with validation attributes)
 *******************************************************/
using System.ComponentModel.DataAnnotations;

public class UserModel
{
    /** Required field */
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    /** Number validation */
    [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
    public int Age { get; set; }

    /** Email format validation */
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}


/*******************************************************
 * 3. CONTROLLER EXAMPLE (Model Binding + Validation)
 *******************************************************/
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    /** POST: api/users */
    [HttpPost]
    public IActionResult CreateUser(UserModel model)
    {
        /** STEP 1 — Check if the model is valid */
        if (!ModelState.IsValid)
        {
            /** Return all validation errors */
            return BadRequest(ModelState);
        }

        /** STEP 2 — If valid, continue processing */
        return Ok(new
        {
            Message = "User created successfully",
            User = model
        });
    }
}


/*******************************************************
 * 4. HOW ASP.NET CORE RETURNS VALIDATION ERRORS
 * -----------------------------------------------------
 * If the JSON is invalid:
 *
 * Example Input:
 *  { "name": "", "age": 10, "email": "wrong-format" }
 *
 * ASP.NET Core returns:
 *
 * {
 *   "Name": ["Name is required"],
 *   "Age": ["Age must be between 18 and 60"],
 *   "Email": ["Invalid email format"]
 * }
 *******************************************************/


/*******************************************************
 * 5. BUILT-IN VALIDATION ATTRIBUTES
 * -----------------------------------------------------
 * [Required]               — field must not be null/empty
 * [MaxLength(x)]           — max characters
 * [MinLength(x)]
 * [Range(min, max)]
 * [EmailAddress]
 * [Phone]
 * [Url]
 * [RegularExpression("")]  — custom regex pattern
 *******************************************************/


/*******************************************************
 * 6. CUSTOM VALIDATION ATTRIBUTE (Example)
 *******************************************************/
public class MustStartWithAAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var input = value as string;

        if (input != null && !input.StartsWith("A"))
        {
            return new ValidationResult("Value must start with letter A");
        }

        return ValidationResult.Success;
    }
}

public class TestModel
{
    [MustStartWithA]
    public string Code { get; set; }
}


/*******************************************************
 * 7. USING VALIDATION IN ACTIONS WITH [FromBody], [FromQuery]
 *******************************************************/

/** Model Binding from JSON */
public IActionResult TestJson([FromBody] UserModel model) => Ok(model);

/** Model Binding from Query String */
public IActionResult TestQuery([FromQuery] string name, [FromQuery] int age)
    => Ok(new { name, age });



/*******************************************************
 * END OF FILE — MODEL BINDING & VALIDATION
 *******************************************************/
