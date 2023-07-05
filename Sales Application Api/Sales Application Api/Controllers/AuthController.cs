using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using Sales_Application_Api.Helpers;
using Sales_Application_Api.Models;
using Sales_Application_Api.Paylodes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sales_Application_Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public AuthController(NorthwindContext context)
        {
            this._context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            LoginResponse response = new LoginResponse();

            if (request.Role == "admin")
            {
                var user = await _context.Admins.FirstOrDefaultAsync(a => a.Email == request.Email);

                if (user == null)
                {
                    return NotFound(new { Message = "User Not Found" });
                }
                if (!PasswordHelper.Decode(request.Password, user.Password))
                {

                    return BadRequest("Password Is Incorrect");
                }

                response.Token = CreateJWT(user);
                response.Message = "Logged In Successfully";
            }
            else if (request.Role == "employee")
            {
                var user = await _context.Employees.FirstOrDefaultAsync(p => p.Email == request.Email);

                if (user == null)
                {
                    return NotFound(new { Message = "User Not Found" });
                }

                if (!PasswordHelper.Decode(request.Password, user.Password))
                {

                    return BadRequest("Password Is Incorrect");
                }

                response.Token = CreateJWT(user);
                response.Message = "Logged In Successfully";
            }
            else if (request.Role == "shipper")
            {
                var user = await _context.Shippers.FirstOrDefaultAsync(p => p.Email == request.Email);

                if (user == null)
                {
                    return NotFound(new { Message = "User Not Found" });
                }

                if (!PasswordHelper.Decode(request.Password, user.Password))
                {

                    return BadRequest("Password Is Incorrect");
                }

                response.Token = CreateJWT(user);
                response.Message = "Logged In Successfully";
            }



            

            return Ok(response);
        }


        [HttpPost("admin-register")]
        public async Task<ActionResult<string>> RegisterAdmin([FromBody] AdminRegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            if (await CheckEmailExistsAsync(request.Email))
            {
                return BadRequest("Email Already Exists");
            }

            Admin admin = new Admin()
            {   
                 AdminId = GenerateAuthorId(),
                 Email = request.Email,
                 Password = PasswordHelper.Encode(request.Password),
                 Role = request.Role
            };

            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();

            return Ok( new { message = "User Registered Successfully" });
        }

        [HttpPost("employee-register")]
        public async Task<ActionResult<string>> RegisterEmployee([FromForm] EmployeeRegisterationRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            if (await CheckEmailExistsAsync(request.Email))
            {
                return BadRequest("Email Already Exists");
            }


            await using var memoryStream = new MemoryStream();
            await request.Photo.CopyToAsync(memoryStream);
            byte[] arr = memoryStream.ToArray();

            Employee employee = new Employee()
            {
                Email = request.Email,
                Password = PasswordHelper.Encode(request.Password),
                Role = request.Role,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Title = request.Title,
                TitleOfCourtesy = request.TitleOfCourtesy,
                BirthDate = request.BirthDate,
                HireDate = request.HireDate,
                Address = request.Address,
                City = request.City,
                Region = request.Region,
                PostalCode = request.PostalCode,
                Country = request.Country,
                HomePhone = request.HomePhone,
                Extension = request.Extension,
                PhotoPath = request.PhotoPath,
                Photo = arr,
                Notes = request.Notes,
                ReportsTo = request.ReportsTo
                };

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User Registered Successfully" });
        }

        [HttpPost("shipper-register")]
        public async Task<ActionResult<string>> RegisterShipper([FromBody] ShipperRegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            if (await CheckEmailExistsAsync(request.Email))
            {
                return BadRequest("Email Already Exists");
            }

            Shipper shipper = new Shipper()
            {
                Email = request.Email,
                Password = PasswordHelper.Encode(request.Password),
                Role = request.Role,
                Phone = request.Phone,
                CompanyName = request.CompanyName
            };

            await _context.AddAsync(shipper);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User Registered Successfully" });
        }

        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            bool res1 = await _context.Employees.AnyAsync(u => u.Email == email);

            bool res2 = await _context.Admins.AllAsync(u => u.Email == email);

            bool res3 = await _context.Shippers.AllAsync(u => u.Email == email);

            return res1 || res2 || res3;
        }

        private string CreateJWT(Admin user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my secret key new");

            var idenity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JsonClaimValueTypes.Json,JsonConvert.SerializeObject(user))
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = idenity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDiscriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateJWT(Shipper user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my secret key new");

            var idenity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JsonClaimValueTypes.Json,JsonConvert.SerializeObject(user))
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = idenity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDiscriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateJWT(Employee user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my secret key new");

            var idenity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JsonClaimValueTypes.Json,JsonConvert.SerializeObject(user))
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = idenity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDiscriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private int GenerateAuthorId()
        {
            Random rd = new Random();
            return rd.Next(1000, 9999);
        }

        private byte[] GetFileBytes(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
