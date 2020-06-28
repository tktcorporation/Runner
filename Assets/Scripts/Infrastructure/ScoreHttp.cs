using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ScoreHttp
{
    public string domain = "asia-northeast1-tacoron.cloudfunctions.net";
    public Scores scores { get; private set; }

    public ScoreHttp()
    {
    }

    public IEnumerator GET(System.IObserver<Scores> observer)
    {
        UnityWebRequest req = UnityWebRequest.Get($"{Url}/ReadScoreHTTP");
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.Log(req.error);
        }
        else if (req.isHttpError)
        {
            Debug.Log(req.error);
        }
        else
        {
            Debug.Log(req.downloadHandler.text);
            this.scores = JsonConvert.DeserializeObject<Scores>(req.downloadHandler.text);
            Debug.Log(scores);
            observer.OnNext(scores);
            observer.OnCompleted();
        }
    }

    public IEnumerator Post(Scores.PostScore score)
    {
        UnityWebRequest req = UnityWebRequest.Post($"{Url}/StoreScoreHTTP", JsonConvert.SerializeObject(score));
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            Debug.Log(req.error);
        }
        else if (req.isHttpError)
        {
            Debug.Log(req.error);
        }
        else
        {
            string result = req.downloadHandler.text;
            Debug.Log(result);
            //observer.OnNext(result);
            //observer.OnCompleted();
        }
    }

    private string Url
    {
        get { return $"https://{this.domain}"; }
    }

    [JsonObject("scores")]
    public class Scores {
        [JsonProperty("items")]
        public List<Score> items;
        [JsonObject("score")]
        public class Score
        {
            [JsonProperty("user_name")]
            public string user_name;
            [JsonProperty("points")]
            public Points points;
            [JsonProperty("total_point")]
            public int total_point;
            [JsonProperty("timestamp")]
            public int timestamp;

            [JsonObject("points")]
            public class Points
            {
                [JsonProperty("of_distance")]
                public int of_distance;
                [JsonProperty("of_coin")]
                public int of_coin;

                public Points(int of_distance, int of_coin)
                {
                    this.of_distance = of_distance;
                    this.of_coin = of_coin;
                }
            }
        }

        [JsonObject("score")]
        public class PostScore
        {
            [JsonProperty("user_name")]
            public string user_name;
            [JsonProperty("points")]
            public Score.Points points;

            public PostScore(string user_name, Score.Points points)
            {
                this.user_name = user_name;
                this.points = points;
            }
        }
    }
}
