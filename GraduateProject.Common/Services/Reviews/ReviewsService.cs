using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Review;
using GraduateProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Reviews
{
    public class ReviewsService : IReviewsService
    {
        #region Fields and Ctor
        private readonly ApplicationDbContext _context;
        private readonly IMapper _autoMapper;

        public ReviewsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _autoMapper = mapper;
        }
        #endregion

        public async Task<bool> AddReview(ReviewDTO model)
        {
            try 
            {
                Review review = _autoMapper.Map<Review>(model);
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteReview(int id)
        {
            try 
            {
                var review = await _context.Reviews.FirstOrDefaultAsync(d => d.Id == id);
                review.IsDeleted = true;
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<List<ReviewListDTO>> GetAcitvatedReviews()
        {
            try 
            {
                List<ReviewListDTO> result = await _context.Reviews.Where(r => r.IsActive == true).Select(r => new ReviewListDTO
                {
                    Id = r.Id,
                    Rate = r.Rate,
                    FullName = r.FullName,
                    Description = r.Description
                }).ToListAsync();
                return result;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<ReviewDTO> GetReviewById(int id)
        {
            try 
            {
                var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
                if (review == null)
                    return null;
                ReviewDTO model = _autoMapper.Map<ReviewDTO>(review);
                return model;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<List<ReviewListDTO>> GetUnActivatedReviews()
        {
            try 
            {
                List<ReviewListDTO> result = await _context.Reviews.Where(r => r.IsActive == false).Select(r => new ReviewListDTO
                {
                    Id = r.Id,
                    Rate = r.Rate,
                    FullName = r.FullName,
                    Description = r.Description

                }).ToListAsync();

                return result;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<bool> UpdateReview(ReviewDTO model)
        {
            try 
            {
                Review review = _autoMapper.Map<Review>(model);
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
