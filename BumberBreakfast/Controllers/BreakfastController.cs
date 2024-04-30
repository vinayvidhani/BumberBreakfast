using BumberBreakfast.Models;
using BumberBreakfast.Models.DatabaseModels;
using BumberBreakfast.Services.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BumberBreakfast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastRepository breakfastRepository;

        public BreakfastController(IBreakfastRepository breakfastRepository)
        {
            this.breakfastRepository = breakfastRepository;
        }

        [HttpGet("getallbreakfast")]
        public async Task<ActionResult<IEnumerable<BreakfastResponse>>> GetBreakFast() 
        {
            var breakfastList = await breakfastRepository.GetAllBreakfast();

            var breakfastresponselist = breakfastList.Select(x => new BreakfastResponse {

                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                LastModifiedDate = x.LastModifiedDateTime,
                //Sweet = x.Sweet,
                //Savory = x.Savory,
            });

            return Ok(breakfastresponselist);
            
        }

        [HttpGet("getbreakfast/{id:Guid}")]
        public async Task<ActionResult<BreakfastResponse>> GetBreakFast(Guid id)
        {
            var breakfast = await breakfastRepository.GetBreakfast(id);
            if(breakfast == null)
            {
                return NotFound();
            }

            var breakfastResponse = new BreakfastResponse()
            {
                Id = breakfast.Id,
                Name = breakfast.Name,
                Description = breakfast.Description,
                StartDate = breakfast.StartDate,
                EndDate = breakfast.EndDate,
                LastModifiedDate = breakfast.LastModifiedDateTime,
                //Sweet = breakfast.Sweet,
                //Savory = breakfast.Savory
            };

            return Ok(breakfastResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreakfast(BreakfastRequest breakfastRequest)
        {
            #region notes
            // client will send information, but it could be less information.
            // Client information might need some modifications and check some custom validation
            // Once we are done with request object we can send it to database to get it store.
            // But the same response we need to send, we may not send some information
            // May be role wise we will send information
            // If any modition required in the request object we always need to implement in constrctor
            // Better to set all the object as getter whichever required like Id should not be changed
            #endregion
            var breakfast = new Breakfast()
            {
                Id = Guid.NewGuid(),
                Name= breakfastRequest.Name,
                Description= breakfastRequest.Description,
                StartDate= breakfastRequest.StartDate,
                EndDate= breakfastRequest.EndDate,
                LastModifiedDateTime = DateTime.Now,
                //Sweet = breakfastRequest.Sweet,
                //Savory=breakfastRequest.Savory,

            };

            await breakfastRepository.CreateBreakfast(breakfast);

            var response = new BreakfastResponse {

                Id = breakfast.Id,
                Name = breakfast.Name,
                Description = breakfast.Description,
                StartDate = breakfast.StartDate,
                EndDate = breakfast.EndDate,
                LastModifiedDate = breakfast.LastModifiedDateTime,
                //Sweet = breakfast.Sweet,
                //Savory = breakfast.Savory

            };

            return CreatedAtAction(nameof(GetBreakFast), new { Id = response.Id}, breakfastRequest);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpsertBreakfast(Guid id, UpsertBrakefast upsertBrakefast)
        {
            return Ok(upsertBrakefast);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBreakfast(Guid id)
        {
            return Ok(id);
        }
    }
}
