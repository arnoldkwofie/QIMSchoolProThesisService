//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//using Microsoft.Data.SqlClient;
//using Dapper;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Authorization;

//using Newtonsoft.Json;

//using System.Data;

//using QIMSchoolProThesisService.Identity.Services;
//using System.Data.SqlClient;

//namespace QIMSchoolPro.Students.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserAccountController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        //private readonly IDatabase _database;
//        private readonly string _connectionString;

//        public UserAccountController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//            //this._database = database;
//            _connectionString = _configuration["IdentityDbConnection"];
//        }
//        [Authorize]
//        [HttpGet("demo")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<IActionResult> Demo()
//        {
//            return Ok();
//        }
//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest model)
//        {
//            // Perform authentication logic here
//            // Validate username and password against the database

//            var user = await AuthenticateUserAsync(model.Username, model.Password);

//            if (user != null)
//            {
//                var token = GenerateToken(user);
//                return Ok(new { Token = token });
//            }

//            return Unauthorized();
//        }

//        private async Task<User> AuthenticateUserAsync(string username, string password)
//        {

//            var user = await GetUser(username);

//            //come back and work on it
//            if (user != null && VerifyPassword(password, user.PasswordHash))
//            {
//                return user;
//            }

//            return null;
//        }

//        private async Task<User> GetUser(string username)
//        {
//            try
//            {
//                User user = null;
//                using var dbConnection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
//                dbConnection.Open();

//                var userQuery = @"SELECT u.*,
//                            [UserId],[RoleId],R.Name Role From Users u 
//                            Join [UserRoles] ur
//                            on ur.UserId = u.Id
//                            JOIN Roles R ON UR.RoleId = R.Id
//                            WHERE UserName = @Username";
//                var userWithRoles = (await dbConnection.QueryAsync<User>(userQuery, new { Username = username })).ToList();
//                if (userWithRoles.Any())
//                {
//                    user = userWithRoles.First();
//                    user.Roles = new List<string>();
//                    user.Roles.AddRange(userWithRoles.Select(x => x.Role).ToList());
//                    //var hasBeCached = await _database.StringSetAsync(key, JsonConvert.SerializeObject(user), TimeSpan.FromDays(1));
//                }
//                return user;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
           
//            //string key = RedisKeys.GetUserKey(username);
//            //var redisValue = await _database.StringGetAsync(key);
//            //if (!redisValue.IsNull)
//            //{
//            //    user = JsonConvert.DeserializeObject<User>(redisValue);
//            //    return user;
//            //}
//        }


//        private bool VerifyPassword(string enteredPassword, string hashedPassword)
//        {
//            var passwordHasher = new PasswordHasher<User>();
//            var verificationResult = passwordHasher.VerifyHashedPassword(null, hashedPassword, enteredPassword);

//            return verificationResult == PasswordVerificationResult.Success;
//        }
//        private string GenerateToken(User user)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim(ClaimTypes.Name, user.UserName),
//                    new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
//                    new Claim(ClaimTypes.NameIdentifier, user.Id),
//                    new Claim(JwtClaimTypes.Id, user.Id),
//                    new Claim(ClaimTypes.Email, user.Email),
//                }),
//                Expires = DateTime.UtcNow.AddMonths(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            // Add multiple role claims
//            if (user.Roles != null)
//            {
//                foreach (var role in user.Roles)
//                {
//                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
//                }
//            }

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//    }

//    public class User
//    {
//        public string PasswordHash { get; set; }
//        public string UserId { get; set; }
//        public string Id { get; set; }
//        public string Role { get; set; }
//        public string RoleId { get; set; }
//        public string UserName { get; set; }
//        public string NormalizedUserName { get; set; }
//        public string Email { get; set; }
//        public string NormalizedEmail { get; set; }
//        public bool EmailConfirmed { get; set; }
//        public string SecurityStamp { get; set; }
//        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
//        public string PhoneNumber { get; set; }
//        public bool PhoneNumberConfirmed { get; set; }
//        public bool TwoFactorEnabled { get; set; }
//        public DateTimeOffset? LockoutEnd { get; set; }
//        public bool LockoutEnabled { get; set; }
//        public int AccessFailedCount { get; set; }
//        public List<string> Roles { get; set; }
//    }
//    public class UserRole
//    {
//        public string UserId { get; set; }
//        public string RoleId { get; set; }

//    }

//    public class LoginRequest
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }
//}
