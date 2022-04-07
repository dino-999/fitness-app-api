using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Dtos;
using Fitness.Entities;
using Fitness.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Controllers
{
    [ApiController]
    [Route("training")]
    public class TrainingDatesController : ControllerBase
    {
        private readonly ITrainingDatesRepository  repository;
        public TrainingDatesController(ITrainingDatesRepository repository)
        {
            this.repository= repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TrainingDateDto>> GetTrainingDatesAsync(){
            var tds= (await repository.GetTrainingDatesAsync()).Select(td => td.AsDto());
            return tds;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDateDto>> GetTrainingDateAsync(Guid id){
            var tds =  await repository.GetTrainingDateAsync(id);
            if (tds is null){
                return NotFound();
            }
            return Ok(tds.AsDto());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> InsertPeopleIntoDateAsync(Guid id, InsertPeopleDto ipdtp){

            var uid = ipdtp.Uid;

            await repository.InsertPeopleAsync(id,uid);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TrainingDateDto>> CreateTrainingDateAsync(CreateTrainingDateDto tdsDto){

            TrainingDate td= new(){
                Id = Guid.NewGuid(),
                Title = tdsDto.Title,
                People= new List<String>(),
                DateOfTraining = tdsDto.DateOfTraining
            };

            await repository.CreateTrainingDateAsync(td);

            return CreatedAtAction(nameof(GetTrainingDatesAsync), new { id= td.Id}, td.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTrainingDateAsync(Guid id, UpdateTrainingDateDto tdsDto){
                var existingTd = await repository.GetTrainingDateAsync(id);

                if(existingTd is null){
                    return NotFound();
                }

                TrainingDate updateTd= existingTd with {
                    Title=tdsDto.Title,
                    DateOfTraining= tdsDto.DateOfTraining
                };
                await repository.UpdateTrainingDateAsync(updateTd);

                return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewsAsync(Guid id){

            var existingTd = await repository.GetTrainingDateAsync(id);
            if (existingTd is null){
                return NotFound();
            }

            await repository.DeleteTrainingDateAsync(id);

            return NoContent();
        }
     
    }

}