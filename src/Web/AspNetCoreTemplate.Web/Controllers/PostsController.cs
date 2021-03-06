using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Web.Controllers
{
    public class PostsController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        // private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            //IDeletableEntityRepository<Post> postRepository,
            ICategoriesService categoriesService,
            IPostsService postsService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            // this.postRepository = postRepository;
            this.postsService = postsService;
            this.userManager = userManager;
        }


        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories
            };
            return View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<PostViewModel>(id);
            if (postViewModel == null)
            {
                return NotFound();
            }
            return View(postViewModel);
        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            //var post = new Post
            //{
            //    Title = input.Title,
            //    Content = input.Content,
            //    CategoryId = input.CategoryId,
            //    //UserId = this.User.Claims.FirstOrDefault()...
            //    //UserId = this.User.Identity.Name()...
            //    UserId = user.Id

            //};

            //await this.postsRepository.AddAsync(post);
            //await this.postsRepository.SaveChangesAsync();

            var postId = await this.postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);
            this.TempData["InfoMessage"] = "Forum post created!";
            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }
    }
}
