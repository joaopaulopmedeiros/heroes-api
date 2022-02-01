namespace WebApi.Domain.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public int ComicsId { get; set; }

        public Comics Comics { get; set; }
    }
}
