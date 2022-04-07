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
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository  repository;
        public NewsController(INewsRepository repository)
        {
            this.repository= repository;
        }

        [HttpGet]
        public async Task<IEnumerable<NewsDto>> GetNewsAsync(){
            var news= (await repository.GetNewsAsync()).Select(news => news.AsDto());
            return news;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetNewAsync(Guid id){
            var news =  await repository.GetNewAsync(id);
            if (news is null){
                return NotFound();
            }
            return Ok(news.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<NewsDto>> CreateNewsAsync(CreateNewsDto newsDto){

            News news= new(){
                Id = Guid.NewGuid(),
                Title = newsDto.Title,
                NewsInfo = newsDto.NewsInfo,
                Category= newsDto.Category,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateNewsAsync(news);

            return CreatedAtAction(nameof(GetNewsAsync), new { id= news.Id}, news.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNewsAsync(Guid id, UpdateNewsDto newsDto){
                var existingNews = await repository.GetNewAsync(id);

                if(existingNews is null){
                    return NotFound();
                }

                News updateNews= existingNews with {
                    Title=newsDto.Title,
                    NewsInfo= newsDto.NewsInfo,
                    Category= newsDto.Category
                };
                await repository.UpdateNewsAsync(updateNews);

                return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewsAsync(Guid id){

            var existingNews = await repository.GetNewAsync(id);
            if (existingNews is null){
                return NotFound();
            }

            await repository.DeleteNewsAsync(id);

            return NoContent();
        }
     
    }

}