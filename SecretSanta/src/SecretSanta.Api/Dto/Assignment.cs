namespace SecretSanta.Api.Dto
{
    public class Assignment
    {
        public User? Giver { get; set; }
        public User? Receiver { get; set; }

        public static Assignment? ToDto(Data.Assignment? assignment)
        {
            if (assignment is null) return null;
            return new Assignment
            {
                Giver = User.ToDto(assignment.Giver),
                Receiver = User.ToDto(assignment.Receiver)
            };
        }
    }
}
