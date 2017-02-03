using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    Collider mCollider;
    Light mLight;

	// Use this for initialization
	void Start () {
        mCollider = GetComponent<Collider>();
        mLight = GetComponentInChildren<Light>();

        if (mCollider == null)
            mCollider = gameObject.AddComponent<BoxCollider>();
        if (mLight == null) {
            mLight = gameObject.AddComponent<Light>();
            mLight.range = 5f;
            mLight.intensity = 2f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (FoveInterface.IsLookingAtCollider(mCollider))
        {
            Debug.Log("COLLISION");
            mLight.enabled = true;
        } else
        {
            mLight.enabled = false;
        }
	}
}
