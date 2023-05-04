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
    public class SubjectsStudentsApiController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectsStudentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var subjectsstudents = _context.SubjectsStudents.Select(i => new
            {
                i.Id,
                i.SubjectsLecturersId,
                i.StudentsGroupsId
            });

            return Json(await DataSourceLoader.LoadAsync(subjectsstudents, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new SubjectsStudents();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.SubjectsStudents.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.SubjectsStudents.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.SubjectsStudents.FirstOrDefaultAsync(item => item.Id == key);

            _context.SubjectsStudents.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("SubjectsLecturersLookup")]
        public async Task<IActionResult> SubjectsLecturersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.SubjectsLecturers.Include(x => x.Lecturers).Include(x => x.Subject)
                         orderby i.LecturersId
                         select new
                         {
                             Value = i.Id,
                             Text = i.Lecturers.LastName + " " + i.Lecturers.FirstName + " " + i.Lecturers.SecondName + " - " + i.Subject.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        [Route("StudentsGroupsLookup")]
        public async Task<IActionResult> StudentsGroupsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StudentsGroups
                         orderby i.Title
                         select new
                         {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(SubjectsStudents model, IDictionary values)
        {
            string ID = nameof(SubjectsStudents.Id);
            string SUBJECTS_LECTURERS_ID = nameof(SubjectsStudents.SubjectsLecturersId);
            string STUDENTS_GROUPS_ID = nameof(SubjectsStudents.StudentsGroupsId);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(SUBJECTS_LECTURERS_ID))
            {
                model.SubjectsLecturersId = Convert.ToInt32(values[SUBJECTS_LECTURERS_ID]);
            }

            if (values.Contains(STUDENTS_GROUPS_ID))
            {
                model.StudentsGroupsId = values[STUDENTS_GROUPS_ID] != null ? Convert.ToInt32(values[STUDENTS_GROUPS_ID]) : (int?)null;
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