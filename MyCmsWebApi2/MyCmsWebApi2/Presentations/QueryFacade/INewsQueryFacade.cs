using MyCmsWebApi2.Presentations.Dtos.NewsDto;


namespace MyCmsWebApi2.Presentations.QueryFacade
{
    public interface INewsQueryFacade
    {
        Task<NewsDto> GetNewsById(int id);
       Task<IEnumerable<NewsDto>> GetAllNews();
    }
}
