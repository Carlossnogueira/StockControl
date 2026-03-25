namespace StockControl.Communication.Response.Login
{
    public class JwtTokenResponse
    {
        public string Token { get; set; } = string.Empty;

        public JwtTokenResponse(string token)
        {
            Token = token;
        }

    }
}
