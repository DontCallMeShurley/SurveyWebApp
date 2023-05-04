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
using Survey_app.Data.Enum;

namespace Survey_app.Controllers
{
    [Route("api/[controller]/[action]")]
    public class QuestionsApiController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionsApiController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var questions = _context.Questions.Select(i => new {
                i.Id,
                i.Text,
                i.QuestionTypes
            });

            // If underlying data is a large SQL table, specify PrimaryKey and PaginateViaPrimaryKey.
            // This can make SQL execution plans more efficient.
            // For more detailed information, please refer to this discussion: https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(questions, loadOptions));
        }
        [HttpGet]
        [Route("GetTypes")]
        public IActionResult GetTypes(DataSourceLoadOptions loadOptions)
        {
            var result = Enum.GetValues(typeof(QuestionTypes)).Cast<QuestionTypes>().Select(a => new
            {
                Id = (int)a,
                Name = Enum.GetName(a)
            }).ToList();
            return Json(DataSourceLoader.Load(result, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Questions();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Questions.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Questions.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Questions.FirstOrDefaultAsync(item => item.Id == key);

            _context.Questions.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Questions model, IDictionary values) {
            string ID = nameof(Questions.Id);
            string TEXT = nameof(Questions.Text);
            string QUESTION_TYPES = nameof(Questions.QuestionTypes);

            if (values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }
            if (values.Contains(QUESTION_TYPES))
            {
                model.QuestionTypes = (QuestionTypes)Convert.ToInt32(values[QUESTION_TYPES]);
            }
            if (values.Contains(TEXT)) {
                model.Text = Convert.ToString(values[TEXT]);
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