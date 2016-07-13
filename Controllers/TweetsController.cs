using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

using Tweets10.Entities;
using Tweets10.Services;

namespace Tweets10.Controllers
{
    public class TweetsController : Controller
    {
        private ITweetService _tweetService;
        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        public async Task<JsonResult> GetAllTweets()
        {
            try
            {
                UserTweets userTweets;
                var result = await _tweetService.GetAll();

                JArray tweetsJArray = JArray.Parse(result);

                if (tweetsJArray.Count > 0)
                {
                    var firstUserJObj = tweetsJArray[0]["user"].Value<JObject>();
                    userTweets = new UserTweets()
                    {
                        User = new User()
                        {
                            Name = firstUserJObj["name"] != null ? firstUserJObj["name"].ToString() : "",
                            ScreenName = firstUserJObj["screen_name"] != null ? firstUserJObj["screen_name"].ToString() : "",
                            ProfileImageUrl = firstUserJObj["profile_image_url"] != null ? firstUserJObj["profile_image_url"].ToString().Replace("normal", "bigger") : ""
                        },

                        Tweets = tweetsJArray.Select(tweet =>
                        {
                            return new Tweet()
                            {
                                Id = tweet["id_str"] != null ? tweet["id_str"].Value<string>() : "",
                                Text = tweet["text"] != null ? tweet["text"].Value<string>() : "",
                                RetweetCount = tweet["retweet_count"] != null ? tweet["retweet_count"].Value<int>() : 0
                            };
                        })
                    };
                }
                else
                {
                    userTweets = null;
                }
                return Json(userTweets);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }
    }
}
