using Mapster;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.API.DBContext;
using SurveyBasket.API.Entites;
using SurveyBasket.API.Servece.IServece;
using System.Threading.Tasks;

namespace SurveyBasket.API.Servece
{


   
    public class Servecepoll : IServecePoll
    {
        ApplicationDBContext db;
        public Servecepoll(ApplicationDBContext db) {

            this.db = db;
        }



        public async Task<Poll> Getasync (int id, CancellationToken cancellationToken)
        {


            return await db.Polls.FindAsync(id,cancellationToken);

        }  

        public async Task<IEnumerable<Poll>>  GetAllAsync(CancellationToken cancellationToken)
        {
            return await db.Polls.ToListAsync(cancellationToken);
        }

        public async Task<Poll> AddAsync(Poll poll, CancellationToken cancellationToken)
        {


            await db.Polls.AddAsync(poll,cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return poll;
        }

        public async Task<Poll> updateAsync(int id, Poll poll,CancellationToken cancellationToken)
        {

            var existingPoll =await Getasync(id,cancellationToken);
            if (existingPoll == null)
            {
                return null;

            }

            existingPoll.Title = poll.Title;
            existingPoll.Description = poll.Description;
          
            existingPoll.CreatedAt = poll.CreatedAt;
            existingPoll.EndedAt = poll.EndedAt;
            await db.SaveChangesAsync(cancellationToken);
            return existingPoll;
        }


        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var Poll = await Getasync(id,cancellationToken);
            if (Poll == null)
            {
                return false;
            }
            db.Polls.Remove(Poll);
            await db.SaveChangesAsync(cancellationToken);
            return true;

        }

     

     public async  Task<Poll> updateAsyncIsPublished(int id  ,CancellationToken cancellationToken)
        {
            var Poll = await Getasync(id, cancellationToken);

            if (Poll == null)
            {
                return null;
            }
            
            Poll.IsPublished = !Poll.IsPublished;
            await db.SaveChangesAsync(cancellationToken);
            return Poll;

        }
    }
}
