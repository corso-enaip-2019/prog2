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
    [Route("villains")]

    public class VillainsController : Controller
    {
        [HttpGet("getall")]
        public IEnumerable<Villain> GetAll()
        {
            return Repository.Instance.GetAllVillains();
        }

        [HttpGet("get/{id}")]
        public Villain GetVillainFromID(int id)
        {
            return Repository.Instance.GetVillainFromID(id);
        }

        [HttpPost("post")]
        public int Post([FromBody]Villain model)
        {
            CheckInputIfModelStateIsValid();
            int newID = Repository.Instance.InsertVillain(model);

            return newID;
        }

        [HttpPut("put/{id}")]
        public void Put(int id, [FromBody]Villain model)
        {
            CheckInputIfModelStateIsValid();
            Repository.Instance.UpdateVillain(id, model);

            return;
        }

        [HttpDelete("delete/{id}")]
        public void DeleteVillainWithID(int id)
        {
            Repository.Instance.RemoveVillainByID(id);

            return;
        }



        [HttpPut("put/{id}")]
        public void PutVillain(int id, [FromBody]Villain model)
        {
            CheckInputIfModelStateIsValid();
            Repository.Instance.UpdateVillain(id, model);

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