namespace SecretSanta.Api.Dto
{
	//DTO
	public class UpdateUser
	{
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? FullName { get => $"{FirstName} {LastName}"; }
	}
}
