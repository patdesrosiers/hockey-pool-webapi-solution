using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HockeyPoolWebApi.API
{
    public class NHLApiClient : INHLApiClient
    {

        private readonly HttpClient _client = new HttpClient();

        public async Task<string> GetBoxScore(int gamePk)
        {
            return await _client.GetStringAsync($"https://statsapi.web.nhl.com/api/v1/game/{gamePk}/boxscore");
        }

        public async Task<string> GetLiveFeed(int gamePk)
        {
            return await _client.GetStringAsync($"https://statsapi.web.nhl.com/api/v1/game/{gamePk}/feed/live");
        }

        public async Task<string> GetPlayoff(string season)
        {
            return await _client.GetStringAsync($"http://statsapi.web.nhl.com/api/v1/tournaments/playoffs?site=en_nhl&expand=round.series,schedule.game.seriesSummary&season={season}");
        }

    }
}