namespace StockControl.Communication.Response.Login
{
    public class JwtTokenResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public JwtTokenResponse(string name, string token)
        {
            Name = name;
            Token = token;
        }

    }
}
