using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.Networking;
using AssemblyCSharp;

public static class ButtonExtension
{
	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener (delegate() {
			OnClick (param);
		});
	}
}

public class Demo : MonoBehaviour
{
	[Serializable]
	public struct Game
	{
		public string withdraw;
		public string deposite;
		public string date;

	}

	Game[] allGames;
	//[SerializeField] Sprite defaultIcon;

	void Start ()
	{
		//fetch data from Json
		StartCoroutine (GetGames ());
	}

	void DrawUI ()
	{
		GameObject buttonTemplate = transform.GetChild (0).gameObject;
		GameObject g;

		int N = allGames.Length;

		for (int i = 0; i < N; i++) {
			g = Instantiate (buttonTemplate, transform);
			g.transform.GetChild(1).GetComponent<Text>().text = allGames[i].date;
			g.transform.GetChild (2).GetComponent <Text> ().text = allGames [i].withdraw;
			g.transform.GetChild (3).GetComponent <Text> ().text = allGames [i].deposite;

			//g.GetComponent <Button> ().AddEventListener (i, ItemClicked);
		}

		Destroy (buttonTemplate);
	}

	//void ItemClicked (int itemIndex)
	//{
	//	Debug.Log ("name " + allGames [itemIndex].withdraw);
	//}

	//***************************************************
	IEnumerator GetGames ()
	{
		
		WWWForm form = new WWWForm();
		form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
		//form.AddField("mobile", "5555555551");
		UnityWebRequest www = UnityWebRequest.Post(StaticStrings.banktransition, form);


		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			print(www.error);
		}
		else {
			if (www.isDone) {
				allGames = JsonHelper.GetArray<Game> (www.downloadHandler.text);
				//Debug.Log(www.downloadHandler.text);
				DrawUI();
			}
		}
	}

	

}
