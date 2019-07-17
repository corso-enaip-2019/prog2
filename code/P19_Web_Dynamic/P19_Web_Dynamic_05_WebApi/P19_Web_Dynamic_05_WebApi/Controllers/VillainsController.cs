using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_05_WebApi.DataAccess;
using P19_Web_Dynamic_05_WebApi.Models;
using P19_Web_Dynamic_05_WebApi.ViewModels;

namespace P19_Web_Dynamic_05_WebApi.Controllers
{
    [Route("villains")]
    public class VillainsController : BaseController
    {
        [HttpGet("get-all")]
        public IEnumerable<VillainRowViewModel> GetAll()
        {
            return Repository.Instance.GetAllVillains();
        }

        [HttpGet("get/{id}")]
        public Villain Get(int id)
        {
            return Repository.Instance.GetVillain(id);
        }

        [HttpPost("post")]
        public int Post([FromBody]VillainEditViewModel viewModel)
        {
            CheckInput();
            var newId = Repository.Instance.InsertVillain(viewModel);
            return newId;
        }

        [HttpPut("put/{id}")]
        public void Put(int id, [FromBody]VillainEditViewModel viewModel)
        {
            CheckInput();
            Repository.Instance.UpdateVillain(id, viewModel);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            Repository.Instance.RemoveVillain(id);
        }
    }
}
