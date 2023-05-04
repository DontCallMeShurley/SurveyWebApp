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
{ [Route("api/[controller]")]
    public class StudentsGroupsApiController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsGroupsApiController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var studentsgroups = _context.StudentsGroups.Select(i => new {
                i.Id,
                i.Title,
                i.CreationDate,
                i.UniversityCampusId
            });

            return Json(await DataSourceLoader.LoadAsync(studentsgroups, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new StudentsGroups();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.StudentsGroups.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.StudentsGroups.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.StudentsGroups.FirstOrDefaultAsync(item => item.Id == key);

            _context.StudentsGroups.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("UniversityCampusesLookup")]
        public async Task<IActionResult> UniversityCampusesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.UniversityCampuses
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(StudentsGroups model, IDictionary values) {
            string ID = nameof(StudentsGroups.Id);
            string TITLE = nameof(StudentsGroups.Title);
            string CREATION_DATE = nameof(StudentsGroups.CreationDate);
            string UNIVERSITY_CAMPUS_ID = nameof(StudentsGroups.UniversityCampusId);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TITLE)) {
                model.Title = Convert.ToString(values[TITLE]);
            }

            if(values.Contains(CREATION_DATE)) {
                model.CreationDate = Convert.ToDateTime(values[CREATION_DATE]);
            }

            if(values.Contains(UNIVERSITY_CAMPUS_ID)) {
                model.UniversityCampusId = values[UNIVERSITY_CAMPUS_ID] != null ? Convert.ToInt32(values[UNIVERSITY_CAMPUS_ID]) : (int?)null;
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