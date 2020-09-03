using System;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using ApiPatents.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiPatents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatentsController : ControllerBase
    {
        private IRepoPatent _repoPatents;

        public PatentsController(IRepoPatent repo) => _repoPatents = repo;

        [HttpGet]
        public IEnumerable<PatentModel> Get() => _repoPatents.Patents;
        [HttpGet("{id}")]
        public PatentModel Get(int id) => _repoPatents[id];
        [HttpPost]
        public PatentModel Post([FromBody] PatentModel pat) =>
        _repoPatents.AddPatent(new PatentModel
        {
            PatentId =          pat.PatentId,
            PatentNumber =      pat.PatentNumber,
            PatentTitle =       pat.PatentTitle,
            PatentNumClaims =   pat.PatentNumClaims,
            PatentClaims =      pat.PatentClaims,
            PatentDate =        pat.PatentDate,
        });
        [HttpPut]
        public PatentModel Put([FromForm] PatentModel pat) => _repoPatents.UpdatePatent(pat);
        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm]JsonPatchDocument<PatentModel> patch)
        {
            PatentModel pat = Get(id);
            if (pat != null)
            {
                patch.ApplyTo(pat);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _repoPatents.DeletePatent(id);
    }
}