namespace SecretSanta.Api.Dto
{
    public class Gift
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int Priority { get; set; }

        public static Gift? ToDto(Data.Gift? gift)
        {
            if (gift is null) return null;
            return new Gift
            {
                Name = gift.Name,
                Url = gift.Url,
                Priority = gift.Priority
            };
        }
    }
}
