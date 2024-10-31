using HW13.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        public const string FilePath = "C:\\Users\\User\\source\\repos\\HW13\\HW13\\respodent.json";
        private List<Person> LoadData() // load data from file to list
        {
            if (!System.IO.File.Exists(FilePath))
            {
                return new List<Person>();
            }

            var jsonData = System.IO.File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                Console.WriteLine("No data found in the file.");
                return new List<Person>();
            }

            var persons = JsonConvert.DeserializeObject<List<Person>>(jsonData);
            return persons ?? new List<Person>();
        }

        private void SaveData(List<Person> users)
        {
            var jsonData = users.Select(JsonConvert.SerializeObject);
            System.IO.File.WriteAllLines(FilePath, jsonData);
        }

        [HttpPost]
        public IActionResult CreateUser(Person user)
        {
            var validator = new PersonValidator();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                string errors = "";
                foreach (var item in result.Errors)
                {
                    errors += item + ", ";
                }
                return BadRequest(errors);
            }

            var userList = LoadData();
            userList.Add(user);
            SaveData(userList);

            return Ok(userList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = LoadData();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var users = LoadData();

            if (id < 0 || id >= users.Count)
            {
                return NotFound("User not found.");
            }

            return Ok(users[id]);
        }

        [HttpGet("filter")]
        public IActionResult GetFiltered([FromQuery] string city)
        {
            var users = LoadData();
            var filteredUsers = users.AsQueryable(); // converts the list of users into an IQueryable, which allows for linq operations that can be executed against the data source 

            if (!string.IsNullOrWhiteSpace(city))
            {
                filteredUsers = filteredUsers.Where(x => x.PersonAddress.City.Equals(city, StringComparison.OrdinalIgnoreCase)); // filters the users to include only those whose city matches the specified city
            }
            return Ok(filteredUsers.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userList = LoadData();

            if (id < 0 || id >= userList.Count)
            {
                return NotFound("User not found.");
            }

            userList.RemoveAt(id);
            SaveData(userList);

            return Ok(userList);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Person updatedUser)
        {
            var validator = new PersonValidator();
            var result = validator.Validate(updatedUser);

            if (!result.IsValid)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var userList = LoadData();

            if (id < 0 || id >= userList.Count)
            {
                return NotFound("User not found.");
            }

            userList[id] = updatedUser;
            SaveData(userList);

            return Ok(userList);
        }
    }
}