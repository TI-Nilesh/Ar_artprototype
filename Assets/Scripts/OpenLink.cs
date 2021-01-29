using UnityEngine;

public class OpenLink : MonoBehaviour {

	public string url;
	//"https://www.huggies.com.my/en-my/auth/try-a-sample"
	
	void OnMouseDown()
	{
		Open ();
	}

	public void Open()
	{
		Application.OpenURL (url);
	}
}
