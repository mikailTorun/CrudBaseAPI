namespace StockMonitor.Application.Abstruction.Token
{
    public interface ITokenHandler
    {
        Models.Token GenerateAccessToken(int min);
        string GenerateRefreshToken();
    }
}
