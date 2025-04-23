using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TANE.Kunde.Api.Model;
using TANE.Kunde.Api.REPO.Interface;

namespace TANE.Kunde.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeREPO _kundeRepo;

        public KundeController(IKundeREPO kundeRepo)
        {
            _kundeRepo = kundeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<KundeModel>>> GetAll()
        {
            var kunder = await _kundeRepo.GetAllKunderAsync();
            return Ok(kunder); // 200 OK
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KundeModel>> GetById(int id)
        {
            var kunde = await _kundeRepo.GetKundeByIdAsync(id);
            if (kunde == null)
                return NotFound(); // 404 NotFound

            return Ok(kunde); // 200 OK
        }

        [HttpPost]
        public async Task<ActionResult> Create(KundeModel kunde)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400 Bad Request

            var resultat = await _kundeRepo.AddKundeAsync(kunde);
            return Ok(resultat); // 200 OK

        }

        [HttpPut]
        public async Task<ActionResult> Update(KundeModel kunde)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400 Bad Request

            try
            {
                var resultat = await _kundeRepo.UpdateKundeAsync(kunde);
                return Ok(resultat); // 200 OK
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Concurrency Exception! Kunden blev ændret af en anden. Prøv igen!"); // 409 Conflict
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultat = await _kundeRepo.DeleteKundeAsync(id);
            if(resultat) return Ok(); // 200 OK
            else return NotFound(); // 404 NotFound
        }
    }
}

