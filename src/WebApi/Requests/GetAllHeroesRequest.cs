namespace WebApi.Requests
{
    public class GetAllHeroesRequest : Request
    {
        #nullable enable
        public string? Name { get; set; }
        public int? Power { get; set; }
    }
}
