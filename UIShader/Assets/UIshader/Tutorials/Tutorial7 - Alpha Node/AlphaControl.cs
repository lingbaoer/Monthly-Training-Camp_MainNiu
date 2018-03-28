using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaControl : MonoBehaviour {
	Material mat;

	void Start () {
		mat = GetComponent<MeshRenderer> ().material;
		StartCoroutine (AlphaAnim ());
	}

	IEnumerator AlphaAnim()
	{
		float alpha = 0;
		while (alpha <= 1) {
			mat.SetFloat ("p", alpha);
			alpha += Time.deltaTime*0.5f;
			yield return new WaitForEndOfFrame();
		}
	}
}
