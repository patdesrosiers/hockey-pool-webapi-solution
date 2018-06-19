using System.Threading.Tasks;

namespace HockeyPoolWebApi.API
{
    public interface INHLApiClient
    {
         Task<string> GetPlayoff(string season);
         Task<string> GetBoxScore(int gamePk);
         Task<string> GetLiveFeed(int gamePk);
    }
}