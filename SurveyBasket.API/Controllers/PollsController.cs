using AutoMapper;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SurveyBasket.API.DTOs.Requist;
using SurveyBasket.API.DTOs.Response;
using SurveyBasket.API.Entites;
using SurveyBasket.API.Servece.IServece;
using System.Threading.Tasks;

namespace SurveyBasket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        public IServecePoll servecePoll;
        private readonly IMapper mapper;
        private readonly IValidator<pollRequist> iValidator;

        public PollsController(IServecePoll servecePoll , IMapper mapper , IValidator<pollRequist> iValidator)
        {
            this.servecePoll = servecePoll;
            this.mapper = mapper;
            this.iValidator = iValidator;
        }


        [HttpGet]
        public async Task<IActionResult>   GetAll(CancellationToken cancellationToken)
        {
            var polls = await servecePoll.GetAllAsync(cancellationToken);
            var response = mapper.Map<IEnumerable< PollResponse>>(polls);

            return Ok(response);

        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult>  Get(int id, CancellationToken cancellationToken)
        {
            var poll = await  servecePoll.Getasync(id,cancellationToken );


            var response = mapper.Map<PollResponse>(poll);

            return poll == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public  async Task<IActionResult> Add(pollRequist poll, CancellationToken cancellationToken)
        {


        

            var map =  mapper.Map<Poll>(poll);

            var newpoll = await servecePoll.AddAsync(map, cancellationToken);


            return CreatedAtAction(nameof(Get), new { id = newpoll.Id }, newpoll);


        }


        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult>  Update(int id, pollRequist pollRequist  ,CancellationToken cancellationToken)
        {

            var map = mapper.Map<Poll>(pollRequist);

            var updatedPoll = await servecePoll.updateAsync(id, map, cancellationToken);
            return updatedPoll == null ? NotFound() : NoContent();
        }
        [HttpPut]

        [Route("UpdatePartial/{id}")]
        public async Task<IActionResult> UpdatePartial(int id,  CancellationToken cancellationToken)
        {
            var updatedPoll = await servecePoll.updateAsyncIsPublished(id, cancellationToken);
            return updatedPoll == null ? NotFound() : NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var isDeleted = await servecePoll.DeleteAsync(id, cancellationToken);
            return isDeleted == null ? NotFound() : NoContent();

        }


    }
}
