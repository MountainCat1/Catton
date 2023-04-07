namespace Authentication.Dto;

public enum AuthMethod {
    Default,
    Google
}

public class AuthRequestDto {
    public string Token { get; set; }
    public AuthMethod Method { get; set; }
}