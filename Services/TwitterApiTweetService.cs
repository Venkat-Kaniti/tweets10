using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using Tweets10.Common;
using Tweets10.Config;

namespace Tweets10.Services
{
    public class TwitterApiTweetService : ITweetService
    {
        private readonly IOptions<TwitterOptions> _twitterOptions;
        
        public TwitterApiTweetService(IOptions<TwitterOptions> twitterOptions)
        {
            _twitterOptions = twitterOptions;
        }
        
        public async Task<string> GetAll()
        {
            var url = 
              "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=" +
              _twitterOptions.Value.ScreenName + 
              "&count=" +
              _twitterOptions.Value.TweetCount;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "OAuth", 
                            OAuthHeader.GenerateOAuthHeader(
                              url,
                              _twitterOptions.Value.ConsumerKey,
                              _twitterOptions.Value.ConsumerSecret
                            )
                        );

                    var response = await httpClient.GetAsync(url);
                    
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
