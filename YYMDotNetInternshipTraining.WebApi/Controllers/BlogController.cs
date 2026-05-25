using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YYMDotNetInternshipTraining.EFCoreSample2.Database.AppDbContextModels;


namespace YYMDotNetInternshipTraining.WebApi.Controllers
{
    // api/blog
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.TblBlogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("Blog not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(YYMDotNetInternshipTraining.WebApi.Models.BlogCreateRequestModel requestModel)
        {
            _db.TblBlogs.Add(NewMethod(requestModel));
            var result = _db.SaveChanges();
            return StatusCode(201, new YYMDotNetInternshipTraining.WebApi.Models.BlogCreateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog created successfully" : "Failed to create blog"
            });
        }

        private static TblBlog NewMethod(YYMDotNetInternshipTraining.WebApi.Models.BlogCreateRequestModel requestModel)
        {
            return new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, YYMDotNetInternshipTraining.WebApi.Models.BlogUpdateRequestModel requestModel)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog not found"
                });
            }

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _db.SaveChanges();

            return Ok(new BlogUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog updated successfully" : "Failed to update blog",
                Data = new YYMDotNetInternshipTraining.WebApi.Models.BlogModel
                {
                    BlogId = item.BlogId,
                    BlogTitle = requestModel.BlogTitle,
                    BlogAuthor = requestModel.BlogAuthor,
                    BlogContent = requestModel.BlogContent
                }
            });
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, YYMDotNetInternshipTraining.WebApi.Models.BlogPatchRequestModel requestModel)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog not found"
                });
            }

            int count = 0;
            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                count++;
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                count++;
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                count++;
                item.BlogContent = requestModel.BlogContent;
            }

            if (count == 0)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Invalid data."
                });
            }

            var result = _db.SaveChanges();

            return Ok(new BlogUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog updated successfully" : "Failed to update blog",
                Data = new YYMDotNetInternshipTraining.WebApi.Models.BlogModel
                {
                    BlogId = item.BlogId,
                    BlogTitle = requestModel.BlogTitle,
                    BlogAuthor = requestModel.BlogAuthor,
                    BlogContent = requestModel.BlogContent
                }
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog not found"
                });
            }

            _db.TblBlogs.Remove(item);
            var result = _db.SaveChanges();

            return Ok(new BlogUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog deleted successfully" : "Failed to delete blog"
            });
        }
    }

    internal class BlogUpdateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public YYMDotNetInternshipTraining.WebApi.Models.BlogModel Data { get; internal set; }
    }

    internal class TblBlog
    {
        public string BlogTitle { get; internal set; }
        public string BlogAuthor { get; internal set; }
        public string BlogContent { get; internal set; }
    }

    internal class AppDbContext
    {
        public object TblBlogs { get; internal set; }

        internal int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}