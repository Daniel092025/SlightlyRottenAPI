

public interface IReviewService
{
    Task<ReviewDto> AddReviewAsync(ReviewDto review);
   

   
}

public interface IRatingService
{
   Task<RateMovieDto> RateAsyncAsync(ReviewDto review);
   
}
