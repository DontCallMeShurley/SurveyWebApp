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
    [Route("api/[controller]/[action]")]
    public class StudentsApiController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsApiController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var students = _context.Students.Select(i => new {
                i.Id,
                i.StudentsGroupsId,
                i.PersonId
            });

            return Json(await DataSourceLoader.LoadAsync(students, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Students();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Students.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Students.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Students.FirstOrDefaultAsync(item => item.Id == key);

            _context.Students.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("StudentsGroupsLookup")]
        public async Task<IActionResult> StudentsGroupsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.StudentsGroups
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        [Route("PersonsLookup")]
        public async Task<IActionResult> PersonsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Persons
                         orderby i.FirstName
                         select new {
                             Value = i.Id,
                             Text = i.Fio
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Students model, IDictionary values) {
            string ID = nameof(Students.Id);
            string STUDENTS_GROUPS_ID = nameof(Students.StudentsGroupsId);
            string PERSON_ID = nameof(Students.PersonId);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(STUDENTS_GROUPS_ID)) {
                model.StudentsGroupsId = Convert.ToInt32(values[STUDENTS_GROUPS_ID]);
            }

            if(values.Contains(PERSON_ID)) {
                model.PersonId = Convert.ToInt32(values[PERSON_ID]);
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