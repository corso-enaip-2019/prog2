using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_05_WebApi.DataAccess;
using P19_Web_Dynamic_05_WebApi.Models;
using P19_Web_Dynamic_05_WebApi.ViewModels;

namespace P19_Web_Dynamic_05_WebApi.Controllers
{
    [Route("superheroes")]
    public class SuperheroesController : BaseController
    {
        [HttpGet("get-all")]
        public IEnumerable<SuperheroRowViewModel> GetAll()
        {
            return Repository.Instance.GetAllSuperheroes();
        }

        [HttpGet("get/{id}")]
        public Superhero Get(int id)
        {
            return Repository.Instance.GetSuperhero(id);
        }

        [HttpPost("post")]
        public int Post([FromBody]SuperheroEditViewModel viewModel)
        {
            CheckInput();
            var newId = Repository.Instance.InsertSuperhero(viewModel);
            return newId;
        }

        [HttpPut("put/{id}")]
        public void Put(int id, [FromBody]SuperheroEditViewModel viewModel)
        {
            CheckInput();
            Repository.Instance.UpdateSuperhero(id, viewModel);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            Repository.Instance.RemoveSuperhero(id);
        }
    }
}
