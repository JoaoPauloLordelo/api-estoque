namespace AprendizadoCSharp.Application.DTOs.Auth
{
    public record NewUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
