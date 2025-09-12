namespace SurveyBasket.API.Entites
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public  DateOnly CreatedAt { get; set; }
        public DateOnly EndedAt { get; set; }
    }
}
