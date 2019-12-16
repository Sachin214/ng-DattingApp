using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }
        // GET api/values
        [Authorize(Roles="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [Authorize(Roles="Member")]
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        // public static List<Employees> lstEmployee = new List<Employees>(){
        //     new Employees{
        //         Id = 1, FirstName = "Sachin", LastName = "Mahandule", City = "Pune", Country = "India", Gender = "0",
        //         EmailId = "Sachin@gmail.com", DateOfBirth = Convert.ToDateTime("12/10/1992")
        //     },
        //     new Employees{
        //         Id = 2, FirstName = "Ram", LastName = "Patil", City = "Nagpur", Country = "India", Gender = "0",
        //         EmailId = "Ram@gmail.com", DateOfBirth = Convert.ToDateTime("08/07/1990")
        //     },
        //     new Employees{
        //         Id = 3, FirstName = "John", LastName = "Schena", City = "New Yark", Country = "US", Gender = "0",
        //         EmailId = "John@gmail.com", DateOfBirth = Convert.ToDateTime("10/19/1985")
        //     },
        //     new Employees{
        //         Id = 4, FirstName = "Mia", LastName = "Malkova", City = "Florida", Country = "US", Gender = "1",
        //         EmailId = "Mia@gmail.com", DateOfBirth = Convert.ToDateTime("07/01/1992")
        //     }
        //     ,
        //     new Employees{
        //         Id = 5, FirstName = "Madhav", LastName = "Patil", City = "Kathmandu", Country = "Nepal", Gender = "0",
        //         EmailId = "Madhav@gmail.com", DateOfBirth = Convert.ToDateTime("08/05/1985")
        //     },
        //     new Employees{
        //         Id = 6, FirstName = "Maya", LastName = "Kolate", City = "Kedarnath", Country = "Nepal", Gender = "1",
        //         EmailId = "Maya@gmail.com", DateOfBirth = Convert.ToDateTime("01/04/1991")
        //     }
        // };
        // List<String> Countries = new List<string>(){
        //     "India", "US", "UK", "Japan", "Nepal"
        // };

        // [HttpGet("GetEmployees")]
        // public IActionResult GetEmployees()
        // {
        //     try
        //     {
        //         var employees = lstEmployee.ToList();
        //         return Ok(employees);
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest();
        //     }
        // }

        // [HttpGet("GetCountries")]
        // public IActionResult GetCountries()
        // {
        //     try
        //     {
        //         var countries = Countries.ToList();
        //         return Ok(countries);
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest();
        //     }
        // }

        // [HttpGet("GetCities")]
        // public IActionResult GetCities(string country)
        // {
        //     try
        //     {
        //         if (country == "India")
        //         {
        //             List<String> Cities = new List<string>(){
        //                 "Pune", "Nagar", "Mumbai", "Nagpur"
        //             };
        //             return Ok(Cities.ToList());
        //         }
        //         else if (country == "US")
        //         {
        //             List<String> Cities = new List<string>(){
        //                 "Florida", "New Yark", "Alabama", "Hawai"
        //             };
        //             return Ok(Cities.ToList());
        //         }
        //         else
        //         {
        //             List<String> Cities = new List<string>(){
        //                 "Kathmandu", "Nepal 1", "Nepal 2", "Nepal 3"
        //             };
        //             return Ok(Cities.ToList());
        //         }
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest();
        //     }
        // }

        // // GET api/values/5
        // [HttpGet("GetEmployee/{id}")]
        // public IActionResult GetEmployee(int id)
        // {
        //     var employee = lstEmployee.Where(x => x.Id == id).FirstOrDefault();
        //     return Ok(employee);
        // }

        // // POST api/values
        // [HttpPost("InsertEmployeeDetails")]
        // public void SaveEmployee(Employees employee)
        // {
        //     lstEmployee.Add(employee);
        // }

        // // PUT api/values/5
        // [HttpPut("UpdateEmployeeDetails")]
        // public void UpdateEmployee(Employees employee)
        // {
        //     try
        //     {
        //         if (employee.Id > 0)
        //         {
        //             var employeeFromList = lstEmployee.Where(x => x.Id == employee.Id).FirstOrDefault();
        //             if (employeeFromList != null)
        //             {
        //                 employeeFromList.FirstName = employee.FirstName;
        //                 employeeFromList.LastName = employee.LastName;
        //                 employeeFromList.EmailId = employee.EmailId;
        //                 employeeFromList.Gender = employee.Gender;
        //                 employeeFromList.City = employee.City;
        //                 employeeFromList.Country = employee.Country;
        //             }
        //         }
        //     }
        //     catch (Exception)
        //     {

        //     }
        // }

        // // DELETE api/values/5
        // [HttpDelete("DeleteEmployeeDetails/{id}")]
        // public void DeleteEmployee(int id)
        // {
        //     try
        //     {
        //         if (id > 0)
        //         {
        //             var employee = lstEmployee.Where(x => x.Id == id).FirstOrDefault();
        //             lstEmployee.Remove(employee);
        //         }
        //     }
        //     catch (Exception)
        //     {

        //     }
        // }
        // [HttpGet("math")]
        // public IActionResult Add()
        // {
        //     MathOperation m = new MathOperation();
        //     return Ok(m.Add(10, 20));
        // }

    }
}
