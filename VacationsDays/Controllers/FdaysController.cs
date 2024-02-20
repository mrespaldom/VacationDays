using Microsoft.AspNetCore.Mvc;
using VacationsDays.Data;
using VacationsDays.Models;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

namespace VacationsDays.Controllers
{
    public class FdaysController : Controller
    {
        private readonly ApplicationDbContext _db;
        private object? bookedDates;

        public FdaysController(ApplicationDbContext db)
        {
            _db = db;
        }

      
        public IActionResult IndexGlobal()
        {
            IEnumerable<Vacation> objVacationList = _db.Vacations;
            return View(objVacationList);
        }

        public IActionResult Index()
        {
            
            var model = _db.Vacations.ToList();
                        
            return View(model);
        }

        public IActionResult Create()
        {

            return View();
        }

        //GET
        public IActionResult Create2()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create2(Vacation obj)
        {
            
            
                // Realizar cálculos
                obj.VacTotalDays = obj.LegalVacYearBef + obj.LegalVacYearBefH2 + obj.LegalVacYear;
                obj.TotalDays = obj.VacTotalDays + obj.ChDays;
                obj.RemainingDays = 0; /*(obj.BookedDays - obj.TotalDays);*/
                obj.BookedDays = 0;  /*(sum of BlokedJson)*/
                obj.BlokedJson = " ";
                obj.SelectedDays= 0;
            //if (ModelState.IsValid)
            //{
                // Adicionar a base de dados
                _db.Vacations.Add(obj);
                _db.SaveChanges();

                TempData["success"] = "Vacation created successfully";
                return RedirectToAction("IndexGlobal");
            //}

            return View(obj);
                           
        }




        [HttpPost]

        public IActionResult Create(Vacation obj)
        {


            // Realizar cálculos
            obj.VacTotalDays = obj.LegalVacYearBef + obj.LegalVacYearBefH2 + obj.LegalVacYear;
            obj.TotalDays = obj.VacTotalDays + obj.ChDays;
            obj.RemainingDays = 0; /*(obj.BookedDays - obj.TotalDays);*/
            obj.BookedDays = 0; 
            
            /*(sum of BlokedJson)*/
            obj.BlokedJson = " ";
            obj.SelectedDays = 0;
            //if (ModelState.IsValid)
            //{
            // Adicionar a base de dados
            _db.Vacations.Add(obj);
            _db.SaveChanges();

            TempData["success"] = "Vacation created successfully";
            return RedirectToAction("Index");
            //}

            return View(obj);

        }

        [HttpGet("GetSelectedDays/{userId}")]
        public IActionResult GetSelectedDays(string userId)
        {
            var vacation = _db.Vacations.FirstOrDefault(v => v.UserId == userId);

            if (vacation != null)
            {
                var selectedDays = JsonConvert.DeserializeObject<List<int>>(vacation.BlokedJson);
                return Ok(selectedDays); // Si los días son serializados como enteros (int)
            }

            return NotFound();
        }


        [HttpPost("CreateWithSelectedDays")]
        public IActionResult CreateWithSelectedDays(List<SelectedDayData> selectedDays)
        {
           // if (selectedDays != null && selectedDays.Any())
            //{
                foreach (var selectedDay in selectedDays)
                {
                    // Encontrar la Vacación correspondiente al UserId
                    Vacation obj = _db.Vacations.FirstOrDefault(v => v.UserId == selectedDay.UserId.ToString());


                    if (obj != null)
                    {
                        // Serializar los días marcados a formato JSON
                        var selectedDaysJson = JsonConvert.SerializeObject(selectedDays.Where(d => d.UserId.ToString() == obj.UserId).Select(d => d.Day).ToList());



                        // Asignar la cadena JSON al campo BlockedJson
                        obj.BlokedJson = selectedDaysJson;

                        // Calcular la suma de todos los días marcados para el usuario en el año respectivo
                        int bookedDays = selectedDays.Count;

                        // Restar esta suma del total de días de vacaciones para obtener los días reservados
                        int remainingDays = obj.TotalDays - bookedDays;

                        // Asignar los valores calculados a las propiedades correspondientes del objeto Vacation
                        obj.BookedDays = bookedDays;
                        obj.RemainingDays = remainingDays;

                        // Guardar los cambios en la base de datos
                        _db.SaveChanges();
                    }
                }
         //   }

            TempData["success"] = "Vacation created successfully";
            return RedirectToAction("Index");
        }







        //[HttpPost("CreateWithSelectedDays")] //SSSSS
        //public IActionResult CreateWithSelectedDays(List<int> selectedDays, List<Vacation> model)
        //{
        //    if (model != null)
        //    {
        //        // Realizar cálculos específicos para los días seleccionados y guardar en la base de datos
        //        for (int i = 0; i < model.Count; i++)
        //        {
        //            Vacation obj = model[i];

        //            if (obj != null)
        //            {
        //                // Obtener los días seleccionados para cada objeto en la lista
        //                var selectedDaysForObj = selectedDays.Take(DateTime.DaysInMonth(obj.Date_Time.Year, obj.Date_Time.Month)).ToList();

        //                // Realizar cálculos y guardar en la base de datos
        //                obj.BookedDays = selectedDaysForObj.Sum();
        //                obj.RemainingDays = obj.BookedDays - obj.TotalDays;

        //                if (ModelState.IsValid)
        //                {
        //                    if (obj.Id == 0)
        //                    {
        //                        // Si el ID es 0, significa que es un nuevo objeto, así que lo agregamos
        //                        _db.Vacations.Add(obj);
        //                    }
        //                    else
        //                    {
        //                        // Si el ID no es 0, significa que ya existe en la base de datos, así que lo actualizamos
        //                        _db.Vacations.Update(obj);
        //                    }
        //                    _db.SaveChanges();
        //                }
        //            }
        //        }

        //    }

        //    TempData["success"] = "Vacation created successfully";
        //    return RedirectToAction("Index");
        //}

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
			
			var vacationFromDb = _db.Vacations.Find(id);
			
			if (vacationFromDb == null)
            {
                return NotFound();
            }

            return View(vacationFromDb);
        }

       
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vacation obj)
        {
        //    if (ModelState.IsValid)
        //    {
                // Realiza cálculos necesarios
                obj.VacTotalDays = (obj.LegalVacYearBef + obj.LegalVacYearBefH2 + obj.LegalVacYear);
                obj.TotalDays = (obj.VacTotalDays + obj.ChDays);

                // Realiza cálculos para RemainingDays y BookedDays
                obj.RemainingDays = CalculateRemainingDays(obj.TotalDays, obj.BookedDays);
            obj.BookedDays = 0;
            obj.BlokedJson = " ";
            obj.SelectedDays = 0;
            //obj.BookedDays = CalculateBookedDays(obj.BlokedJson);

            // Actualiza la entidad en la base de datos
            _db.Vacations.Update(obj);
                _db.SaveChanges();

                TempData["success"] = "Vacation updated successfully";
                return RedirectToAction("IndexGlobal");
            //}

            return View(obj);
        }

        // Métodos de cálculo
        private int CalculateRemainingDays(int totalDays, int bookedDays)
        {
            return totalDays - bookedDays;
        }

        


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vacationFromDb = _db.Vacations.Find(id);
           
            if (vacationFromDb == null)
            {
                return NotFound();
            }

            return View(vacationFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Vacations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Vacations.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("IndexGlobal");

        }
    }


}
