using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(CommonFunction.DelayToInvokeDo(() =>
        {

        }, 3.5f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
