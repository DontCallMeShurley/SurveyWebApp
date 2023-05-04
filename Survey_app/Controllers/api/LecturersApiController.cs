using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Survey_app.Data;
using Survey_app.Models;

namespace Survey_app.Controllers
{
    [Route("api/[controller]")]
    public class LecturersApiController : Controller
    {
        private ApplicationDbContext _context;

        public LecturersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var lecturers = _context.Lecturers.Select(i => new
            {
                i.Id,
                i.FirstName,
                i.SecondName,
                i.LastName,
                i.DateOfBirth,
                i.Email,
                i.Subjects
            });

            return Json(await DataSourceLoader.LoadAsync(lecturers, loadOptions));
        }
        [HttpGet]
        [Route("GetLecturesSubjects")]
        public async Task<IActionResult> GetLecturesSubjects(DataSourceLoadOptions loadOptions)
        {
            var lecturers = _context.Subjects.Select(i => new
            {
                i.Id,
                i.Title
            });
            return Json(await DataSourceLoader.LoadAsync(lecturers, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Lecturers();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Lecturers.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Lecturers.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.Lecturers.FirstOrDefaultAsync(item => item.Id == key);

            _context.Lecturers.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("Lecturers_postsLookup")]
        public async Task<IActionResult> Lecturers_postsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LecturersPosts
                         orderby i.Position
                         select new
                         {
                             Value = i.Id,
                             Text = i.Position
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Lecturers model, IDictionary values)
        {
            string firstName = nameof(Lecturers.FirstName);
            string secondName = nameof(Lecturers.SecondName);
            string lastName = nameof(Lecturers.LastName);
            string dateOfBirth = nameof(Lecturers.DateOfBirth);
            string email = nameof(Lecturers.Email);
            string lecturersPostId = nameof(Lecturers.LecturersPostId);

            if (values.Contains(firstName))
            {
                model.FirstName = Convert.ToString(values[firstName]);
            }

            if (values.Contains(secondName))
            {
                model.SecondName = Convert.ToString(values[secondName]);
            }

            if (values.Contains(lastName))
            {
                model.LastName = Convert.ToString(values[lastName]);
            }

            if (values.Contains(dateOfBirth))
            {
                model.DateOfBirth = values[dateOfBirth] != null ? Convert.ToDateTime(values[dateOfBirth]) : (DateTime?)null;
            }

            if (values.Contains(email))
            {
                model.Email = Convert.ToString(values[email]);
            }

            if (values.Contains(lecturersPostId))
            {
                model.LecturersPostId = Convert.ToInt32(values[lecturersPostId]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}