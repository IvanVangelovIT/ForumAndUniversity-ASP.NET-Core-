using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }
        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                //UserId = this.User.Claims.FirstOrDefault()...
                //UserId = this.User.Identity.Name()...
                UserId = userId,

            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
            return post.Id;
        }


        public T GetById<T>(int id)
        {
            var post = this.postsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return post;
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return this.postsRepository
                .All()
                .Count(x => x.CategoryId == categoryId);
        }

        IEnumerable<T> IPostsService.GetByCategoryId<T>(int categoryId, int? take, int? skip = 0)
        {
            var query = this.postsRepository
                            .All()
                            .OrderByDescending(x => x.CreatedOn)
                            .Where(x => x.CategoryId == categoryId)
                            .Skip((int)skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }
    }
    }
