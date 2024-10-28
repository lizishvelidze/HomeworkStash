using Homework12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Homework12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string FilePath = "C:\\Users\\User\\source\\repos\\Homework12\\Homework12\\appointment.json";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/appointment", Name = "Appointment")]
        public IActionResult Appointment()
        {
            return View();
        }
        private bool IsAppointmentTimeTaken(List<Appointment> appointments, Appointment newAppointment)
        {
            foreach (var appointment in appointments)
            {

                if (appointment.Doctor == newAppointment.Doctor && appointment.Time == newAppointment.Time) // იგივე ექიმს იმ დროზე უკვე თუ აქვს დაკავებული
                {
                    return true; // თუ დაკავებულია
                }
            }
            return false;
        }

        [HttpPost]
        [Route("/appointment", Name = "BookAppointment")]
        public IActionResult Appointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var appointments = LoadAppointments(); // loads appointment list to check
                if (IsAppointmentTimeTaken(appointments, appointment))
                {
                    ViewBag.Message = "This time slot is already taken for the selected doctor."; // ვერ ვაპრინტინებ
                    return View(appointment);
                }
                appointments.Add(appointment);
                SaveAppointments(appointments);
            }
            else
            {
                foreach (var modelState in ModelState.Values) // / helps manage the state of the data. contains info about the model, including validation errors and the values submitted by the user
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
            }
            return View(appointment);
        }
           
        private List<Appointment> LoadAppointments()
        {
            if (!System.IO.File.Exists(FilePath))
            {
                return new List<Appointment>();
            }

            var json = System.IO.File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Appointment>>(json) ?? new List<Appointment>(); // return an empty list if the deserialized result is null
        }

        private void SaveAppointments(List<Appointment> appointments)
        {
            var json = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, json);
        }
    }
}