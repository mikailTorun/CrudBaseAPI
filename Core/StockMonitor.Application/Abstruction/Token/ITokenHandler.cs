namespace StockMonitor.Application.Abstruction.Token
{
    public interface ITokenHandler
    {
        Models.Token GenerateAccessToken(int min);
        Models.Token GenerateRefreshToken(int min);
    }
}
