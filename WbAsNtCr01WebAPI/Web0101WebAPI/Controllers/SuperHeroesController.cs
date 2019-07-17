using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Web0101WebAPI.DataAccess;
using Web0101WebAPI.Infrastructure;
using Web0101WebAPI.Models;

namespace Web0101WebAPI.Controllers
{
    [Route("superheroes")]
    //[Route("api/[controller]")]
    //    [ApiController]
    //public class SHeroesController : ControllerBase
    public class SuperHeroesController : Controller
    {
        [HttpGet("getall")]
        public IEnumerable<SuperHero> GetAll()
        {
            return Repository.Instance.GetAllSuperHeroes();
        }

        [HttpGet("get/{id}")]
        public SuperHero GetHeroFromID(int id)
        {
            return Repository.Instance.GetSuperHeroesFromID(id);
        }

        [HttpPost("post")]
        public int Post([FromBody]SuperHero model)
        {
            CheckInputIfModelStateIsValid();
            int newID = Repository.Instance.InsertSuperHero(model);

            return newID;
        }

        [HttpPut("put/{id}")]
        public void Put(int id, [FromBody]SuperHero model)
        {
            CheckInputIfModelStateIsValid();
            Repository.Instance.UpdateSuperHero(id, model);

            return;
        }

        [HttpDelete("delete/{id}")]
        public void DeleteHeroWithID(int id)
        {
            Repository.Instance.RemoveSuperHeroByID(id);

            return;
        }

        [HttpPut("put/{id}")]
        public void PutHeroWithID()
        {

            return;
        }
        
        private void CheckInputIfModelStateIsValid()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value
                        .Errors
                        .Select(y => y.ErrorMessage));

                var errorMessage = string.Join("; ", errors);

                throw new InvalidInputException(errorMessage);
            }
        }
    }
}