namespace Account.Contracts;

public enum AuthMethod {
    Default,
    Google
}

public class AuthRequestModel {
    public string Token { get; set; }
    public AuthMethod Method { get; set; }
}