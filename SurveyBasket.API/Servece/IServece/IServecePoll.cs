using Microsoft.AspNetCore.Mvc;
using SurveyBasket.API.Models;

namespace SurveyBasket.API.Servece.IServece
{
    public interface IServecePoll
    {
        IEnumerable<Poll> GetAll();

        Poll Get(int id);
         Poll Add(Poll poll);

        Poll update(int id, Poll poll);
        bool Delete(int id);
    }
}
