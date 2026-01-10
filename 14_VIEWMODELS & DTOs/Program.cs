/*******************************************************
 * VIEWMODELS & DTOs — ASP.NET Core 9
 * -----------------------------------------------------
 * This tutorial explains:
 * 1. What DTOs are and why we use them
 * 2. What ViewModels are
 * 3. Differences between DTOs, ViewModels, and Entities
 * 4. How to create and use DTOs in Web APIs
 * 5. How to create and use ViewModels in MVC
 * 6. Mapping examples (manual + AutoMapper)
 *******************************************************/


/*******************************************************
 * 1. WHAT IS A DTO? (Data Transfer Object)
 * -----------------------------------------------------
 * DTO: A simple class used to transfer data between:
 *    - Client ⇄ Server
 *    - Service layers
 *    - Controllers ⇄ Database layer
 *
 * WHY USE DTOs?
 *  - Prevents exposing database entities directly
 *  - Improves security (hide sensitive fields)
 *  - Cleaner API responses
 *  - Allows custom shapes of data
 *  - Better separation of concerns
 *******************************************************/


/*******************************************************
 * 2. WHAT IS A VIEWMODEL?
 * -----------------------------------------------------
 * A ViewModel is used in MVC (Razor Views) to:
 *   - Send complex data to the UI
 *   - Combine multiple models
 *   - Add UI-specific formatting data
 *   - Provide data display logic (but NOT business logic)
 *******************************************************/


/*******************************************************
 * 3. ENTITY vs DTO vs VIEWMODEL
 * -----------------------------------------------------
 * ENTITY:
 *   - Represents database table
 *   - Contains full structure
 *
 * DTO:
 *   - Represents what API returns/receives
 *   - Only required fields
 *
 * VIEWMODEL:
 *   - Represents what the UI needs to display
 *   - Can combine multiple DTOs/entities
 *******************************************************/


/*******************************************************
 * 4. EXAMPLE DATABASE ENTITY
 *******************************************************/
public class UserEntity
{
    public int Id { get; set; }

    /** Sensitive field — DO NOT return to API */
    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public DateTime CreatedAt { get; set; }
}


/*******************************************************
 * 5. SIMPLE DTO EXAMPLE
 *******************************************************/
public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
}


/*******************************************************
 * 6. CREATE DTO FOR USER REGISTRATION
 *******************************************************/
public class RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}


/*******************************************************
 * 7. CONTROLLER USING DTOs
 *******************************************************/
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    /** POST: api/users/register */
    [HttpPost("register")]
    public IActionResult Register(RegisterUserDto model)
    {
        /** Convert DTO into entity */
        var user = new UserEntity
        {
            Email = model.Email,
            FullName = model.FullName,
            PasswordHash = Hash(model.Password),
            CreatedAt = DateTime.UtcNow
        };

        /** Normally: save to database here */
        
        /** Convert entity back to DTO to return */
        var result = new UserDto
        {
            Id = 10,
            Email = user.Email,
            FullName = user.FullName
        };

        return Ok(result);
    }

    private string Hash(string input) => $"HASH({input})";
}


/*******************************************************
 * 8. VIEWMODEL EXAMPLE (FOR RAZOR UI)
 *******************************************************/
public class UserProfileViewModel
{
    /** Data from entity */
    public string FullName { get; set; }
    public string Email { get; set; }

    /** Extra data only for UI */
    public int TotalPosts { get; set; }
    public string MembershipStatus { get; set; }
}


/*******************************************************
 * 9. VIEWMODEL CONTROLLER EXAMPLE
 *******************************************************/
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        /** Imagine fetching from database */
        var user = new UserEntity
        {
            FullName = "Nour",
            Email = "nour@test.com"
        };

        var vm = new UserProfileViewModel
        {
            FullName = user.FullName,
            Email = user.Email,
            TotalPosts = 12,
            MembershipStatus = "Premium"
        };

        return View(vm);
    }
}


/*******************************************************
 * 10. AUTO-MAPPING USING AUTOMAPPER
 *******************************************************/

/** Step 1 — Create mapping profile */
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserDto>();
        CreateMap<RegisterUserDto, UserEntity>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}

/** Step 2 — Inject AutoMapper into controller */
public class UsersAutoMapperController : ControllerBase
{
    private readonly IMapper _mapper;

    public UsersAutoMapperController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost("register-auto")]
    public IActionResult Register(RegisterUserDto model)
    {
        var user = _mapper.Map<UserEntity>(model);

        user.PasswordHash = "HASHED";

        var result = _mapper.Map<UserDto>(user);

        return Ok(result);
    }
}

