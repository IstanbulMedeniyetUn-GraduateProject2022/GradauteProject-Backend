using GraduateProject.Common.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Reviews
{
    public interface IReviewsService
    {
        public Task<List<ReviewListDTO>> GetAcitvatedReviews();
        public Task<List<ReviewListDTO>> GetUnActivatedReviews();
        public Task<ReviewDTO> GetReviewById(int id);
        public Task<bool> AddReview(ReviewDTO model);
        public Task<bool> UpdateReview(ReviewDTO model);
        public Task<bool> DeleteReview(int id);
    }
}
