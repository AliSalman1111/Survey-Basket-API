using AutoMapper;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.API.DTOs.Requist;
using SurveyBasket.API.DTOs.Response;
using SurveyBasket.API.Models;
using SurveyBasket.API.Servece.IServece;

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
        public IActionResult GetAll()
        {
            var polls = servecePoll.GetAll();
            var response = mapper.Map<IEnumerable< PollResponse>>(polls);

            return Ok(response);

        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var poll = servecePoll.Get(id);

          
            var response = mapper.Map<PollResponse>(poll);

            return poll == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(pollRequist poll)
        {


            //var validationResult = iValidator.Validate(poll);
            //if(!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}

            var map = mapper.Map<Poll>(poll);

            var newpoll = servecePoll.Add(map);


            return CreatedAtAction(nameof(Get), new { id = newpoll.Id }, newpoll);


        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update(int id, Poll poll)
        {
            var updatedPoll = servecePoll.update(id, poll);
            return updatedPoll == null ? NotFound() : NoContent();
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = servecePoll.Delete(id);
            return isDeleted == null ? NotFound() : NoContent();

        }


    }
}
