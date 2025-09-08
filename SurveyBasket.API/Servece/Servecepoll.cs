using SurveyBasket.API.Models;
using SurveyBasket.API.Servece.IServece;

namespace SurveyBasket.API.Servece
{
    public class Servecepoll : IServecePoll
    {
        private readonly List<Poll> polls = new List<Poll>() {
        new Poll
        {
           Id = 1,
           Title="Ali",
           Description="dkfjdkg"
        }

        };
        public Poll Get(int id)
        {
            return polls.FirstOrDefault(x=>x.Id==id);
           
        }

        public IEnumerable<Poll> GetAll()
        {
            return polls;
        }

        public Poll Add(Poll poll)
        {

            poll.Id = polls.Count + 1;
            polls.Add(poll);
            return poll;
        }

        public Poll update(int id, Poll poll)
        {

            var existingPoll = Get(id);
            if (existingPoll == null)
            {
                return null;

            }

            existingPoll.Title = poll.Title;
            existingPoll.Description = poll.Description;
            return existingPoll;
        }


         public  bool Delete(int id)
        {
           var Poll = Get(id);
            if (Poll == null)
            {
                return false;
            }
            polls.Remove(Poll);
            return true;

        }
    }
}
