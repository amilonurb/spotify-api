namespace SpotifyWebAPI.Shared.Context
{
    public interface IMyHttpContextAccessor
    {
        string GetCurrentBaseUrl();
    }
}