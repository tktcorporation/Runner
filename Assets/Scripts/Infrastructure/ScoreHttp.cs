using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ScoreHttp
{
    private string domain;
    public Scores scores { get; private set; }

    public ScoreHttp(string domain)
    {
        this.domain = domain;
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
            //this.scores = JsonUtility.FromJson<Scores>(req.downloadHandler.text);
            this.scores = JsonConvert.DeserializeObject<Scores>(req.downloadHandler.text);
            Debug.Log(scores);
            observer.OnNext(scores);
            observer.OnCompleted();
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
            }
        }
    }
}
