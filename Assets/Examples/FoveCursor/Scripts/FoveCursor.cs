using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveCursor : MonoBehaviour {

    [Tooltip("Cursor Object")]
    public GameObject cursor;
    [Tooltip("Turn on debugging")]
    public bool debug;

    GazeConvergenceData gcd;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (cursor != null)
        {
            gcd = FoveInterface.GetGazeConvergence();
            cursor.transform.position = gcd.ray.GetPoint(gcd.distance);

            if (debug) Debug.DrawRay(gcd.ray.origin, gcd.ray.direction, Color.green);
        }
	}
}
