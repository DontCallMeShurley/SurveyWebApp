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
    [Route("api/[controller]")]
    public class PersonApiController : Controller
    {
        private ApplicationDbContext _context;

        public PersonApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList(DataSourceLoadOptions loadOptions)
        {
            var persons = _context.Persons.Select(i => new
            {
                i.Id,
                i.FirstName,
                i.SecondName,
                i.LastName,
                i.Email,
                i.Login,
                i.Fio,
                i.RolesTypes,
                i.SexType
            });

            return Json(await DataSourceLoader.LoadAsync(persons, loadOptions));
        }

        [HttpGet]
        [Route("GetRolesName")]
        public IActionResult GetRolesNameAsync(DataSourceLoadOptions loadOptions)
        {
            var result = Enum.GetValues(typeof(RolesTypes)).Cast<RolesTypes>().Select(a => new
            {
                Id = (int)a,
                Name = Enum.GetName(a)
            }).ToList();
            return Json(DataSourceLoader.Load(result, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Person();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            string password = GeneratePassword();
            model.Password = BCrypt.Net.BCrypt.HashPassword(password);
            var result = _context.Persons.Add(model);

           
            await EmailSender.Instance.SendEmail(model.Email, password, model.Fio);

            if (model.RolesTypes == RolesTypes.Student)
            {
                _context.Students.Add(new Students() { Person = model });
            }
            await _context.SaveChangesAsync();
            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Persons.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Persons.FirstOrDefaultAsync(item => item.Id == key);

            _context.Persons.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Person model, IDictionary values)
        {
            string id = nameof(Person.Id);
            string firstName = nameof(Person.FirstName);
            string secondName = nameof(Person.SecondName);
            string lastName = nameof(Person.LastName);
            string email = nameof(Person.Email);
            string login = nameof(Person.Login);
            string rolesType = nameof(Person.RolesTypes);

            if (values.Contains(id))
            {
                model.Id = Convert.ToInt32(values[id]);
            }

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

            if (values.Contains(email))
            {
                model.Email = Convert.ToString(values[email]);
            }

            if (values.Contains(login))
            {
                model.Login = Convert.ToString(values[login]);
            }
            if (values.Contains(rolesType))
            {
                model.RolesTypes = (RolesTypes)Convert.ToInt32(values[rolesType]);
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

        private string GeneratePassword()
        {
            Random random = new Random();
            int randomPassword = random.Next(10000, 100000);
            return randomPassword.ToString();
        }
    }
}