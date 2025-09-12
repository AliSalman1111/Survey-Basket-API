using Microsoft.AspNetCore.Mvc;
using SurveyBasket.API.Entites;

namespace SurveyBasket.API.Servece.IServece
{
    public interface IServecePoll
    {
       Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken);

        Task<Poll> Getasync(int id,CancellationToken cancellationToken);
        Task<Poll> AddAsync(Poll poll ,CancellationToken cancellationToken);

        Task<Poll> updateAsync(int id, Poll poll, CancellationToken cancellationToken);
        Task<Poll> updateAsyncIsPublished(int id, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);


    }

}
