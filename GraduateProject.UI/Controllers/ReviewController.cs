using GraduateProject.Common.DTOs.Review;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Services.Reviews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewsService _reviewsService;
        public ReviewController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<ReviewListDTO>>> GetActivatedReviews()
        {
            try
            {
                var result = await _reviewsService.GetAcitvatedReviews();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(int id)
        {
            try
            {
                var result = await _reviewsService.GetReviewById(id);
                if (result == null)
                    return Json(new ResponseResult(ResponseType.Error, result.ToString()));

                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddReview(ReviewDTO review)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _reviewsService.AddReview(review);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateReview(ReviewDTO review)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _reviewsService.UpdateReview(review);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }
    }
}
