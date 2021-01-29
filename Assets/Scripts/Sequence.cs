using UnityEngine;
using System.Collections;

public class Sequence : MonoBehaviour {

	public GameObject[] objectsToEnable;

	public float delay;

	public void EnableObject()
	{
		StartCoroutine (Enable ());
	}

	IEnumerator Enable()
	{
		yield return new WaitForSeconds(delay);

		for (int i = 0; i < objectsToEnable.Length; i++)
		{
			objectsToEnable[i].SetActive (true);
		}
	}
}
