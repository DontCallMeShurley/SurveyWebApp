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
    public class SubjectsLecturersApiController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectsLecturersApiController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var subjectslecturers = _context.SubjectsLecturers.Select(i => new {
                i.Id,
                i.LecturersId,
                i.SubjectId
            });

            return Json(await DataSourceLoader.LoadAsync(subjectslecturers, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new SubjectsLecturers();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.SubjectsLecturers.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.SubjectsLecturers.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.SubjectsLecturers.FirstOrDefaultAsync(item => item.Id == key);

            _context.SubjectsLecturers.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("LecturersLookup")]
        public async Task<IActionResult> LecturersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Lecturers
                         orderby i.FirstName
                         select new {
                             Value = i.Id,
                             Text = i.SecondName + " " + i.FirstName + " " + i.LastName,
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> SubjectsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Subjects
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(SubjectsLecturers model, IDictionary values) {
            string ID = nameof(SubjectsLecturers.Id);
            string LECTURERS_ID = nameof(SubjectsLecturers.LecturersId);
            string SUBJECT_ID = nameof(SubjectsLecturers.SubjectId);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(LECTURERS_ID)) {
                model.LecturersId = Convert.ToInt32(values[LECTURERS_ID]);
            }

            if(values.Contains(SUBJECT_ID)) {
                model.SubjectId = Convert.ToInt32(values[SUBJECT_ID]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}