namespace SurveyBasket.API.DTOs.Requist
{
    public class pollRequist
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
       
        public DateOnly CreatedAt { get; set; }
        public DateOnly EndedAt { get; set; }
    }
}
