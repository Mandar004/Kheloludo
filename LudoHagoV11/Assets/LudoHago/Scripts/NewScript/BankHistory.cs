//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BankHistory : MonoBehaviour
{

    public Text amount;
    public Text datetime;
    public GameObject Showhistory;

    [Serializable]
    public struct Post
    {
        public string bet_amount;
        public string datetime;

    }

    Post[] posts;


    private void Start()
    {
        GetPosts();
    }
    IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public void GetPosts()
    {
        StartCoroutine(GetRequest("http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/bet_amount.php", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                // posts = JsonConvert.DeserializeObject<Post[]>(req.downloadHandler.text);


                GameObject Showhistory = transform.GetChild(0).gameObject;
                GameObject g;
                //Debug.Log(req.downloadHandler.text);
                foreach (Post post in posts)
                {

                    Instantiate(Showhistory);
                   
                    amount.text = post.bet_amount.ToString();
                    datetime.text = post.datetime.ToString();

                }
            }
        }));
    }

}

