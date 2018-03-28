using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveControl : MonoBehaviour {
	Material mat;
	bool visible = true;
	float speed = 0.5f;
	void Start()
	{
		mat = GetComponent<Renderer> ().material;
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(visible)
				StartCoroutine (Go ());
			else
				StartCoroutine (Back ());
		}
	}
	IEnumerator Go()
	{
		float pcg = 0;
		while (pcg < 1) {
			pcg += speed*Time.deltaTime;
			mat.SetFloat ("_pcg",pcg);
			yield return new WaitForEndOfFrame ();
		}
		pcg = 1;
		mat.SetFloat ("_pcg",pcg);
		visible = false;
	}
	IEnumerator Back()
	{
		float pcg = 1;
		while (pcg >0) {
			pcg -= speed*Time.deltaTime;
			mat.SetFloat ("_pcg",pcg);
			yield return new WaitForEndOfFrame ();
		}
		pcg = 0;
		mat.SetFloat ("_pcg",pcg);
		visible = true;
	}
}
