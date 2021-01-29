using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

	public void Load(int id)
	{
		SceneManager.LoadScene (id);
	}
}
