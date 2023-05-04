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
using Survey_app.Data.Enum;
using Survey_app.Models;

namespace Survey_app.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExceptionsApiController : Controller
    {
        private ApplicationDbContext _context;

        public ExceptionsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetSubject")]
        public async Task<IActionResult> GetSubject(DataSourceLoadOptions loadOptions)
        {
            var exceptions = _context.Exceptions.Include(x => x.Question).Where(x => x.ExceptionType == ExceptionType.Subject).Select(i => new
            {
                i.Id,
                i.QuestionId
            });

            return Json(await DataSourceLoader.LoadAsync(exceptions, loadOptions));
        }

        [HttpGet]
        [Route("GetLectures")]
        public async Task<IActionResult> GetLectures(DataSourceLoadOptions loadOptions)
        {
            var exceptions = _context.Exceptions.Where(x => x.ExceptionType == ExceptionType.Lectures).Select(i => new
            {
                i.Id,
                i.QuestionId
            });

            return Json(await DataSourceLoader.LoadAsync(exceptions, loadOptions));
        }

        [HttpPost]
        [Route("PostSubject")]
        public async Task<IActionResult> PostSubject(string values)
        {
            var model = new Exceptions();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            model.ExceptionType = ExceptionType.Subject;
            var result = _context.Exceptions.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }
        [HttpPost]
        [Route("PostLectures")]
        public async Task<IActionResult> PostLectures(string values)
        {
            var model = new Exceptions();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            model.ExceptionType = ExceptionType.Lectures;
            var result = _context.Exceptions.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Exceptions.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Exceptions.FirstOrDefaultAsync(item => item.Id == key);

            _context.Exceptions.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        [Route("QuestionsLookup")]
        public async Task<IActionResult> QuestionsLookup(DataSourceLoadOptions loadOptions)
        {
            //Группировка вопросов, дабы исключить дубли
            var groupQuestions = _context.Questions.GroupBy(x => x.Text).Select(x => new {Text = x.Key, Id = x.Max(y => y.Id) });
            var lookup = from i in groupQuestions
                         orderby i.Text
                         select new
                         {
                             Value = i.Id,
                             i.Text
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Exceptions model, IDictionary values)
        {
            string ID = nameof(Exceptions.Id);
            string QUESTION_ID = nameof(Exceptions.QuestionId);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(QUESTION_ID))
            {
                model.QuestionId = Convert.ToInt32(values[QUESTION_ID]);
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