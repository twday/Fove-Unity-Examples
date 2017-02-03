using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveCursor : MonoBehaviour {

    [Tooltip("Turn on debugging")]
    public bool debug;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        FoveInterface.EyeRays eyes = FoveInterface.GetEyeRays();
        RaycastHit hitLeft, hitRight;

        switch (FoveInterface.CheckEyesClosed())
        {
            case Fove.EFVR_Eye.Neither:
                if (debug)
                {
                    Debug.Log("Left Eye: " + eyes.left.ToString());
                    Debug.DrawRay(eyes.left.origin, eyes.left.direction, Color.green);

                    Debug.Log("Right Eye: " + eyes.right.ToString());
                    Debug.DrawRay(eyes.right.origin, eyes.right.direction, Color.red);
                }

                Physics.Raycast(eyes.left, out hitLeft, Mathf.Infinity);
                Physics.Raycast(eyes.right, out hitRight, Mathf.Infinity);
                if (hitLeft.point != Vector3.zero && hitRight.point != Vector3.zero)
                {
                    transform.position = hitLeft.point + ((hitRight.point - hitLeft.point) / 2);
                } else
                {
                    transform.position = eyes.left.GetPoint(3.0f) + ((eyes.right.GetPoint(3.0f) - eyes.left.GetPoint(3.0f)) / 2);
                }
                
                break;
            case Fove.EFVR_Eye.Left:
                if (debug) Debug.Log("Right Eye: " + eyes.right.ToString());

                Physics.Raycast(eyes.right, out hitRight, Mathf.Infinity);
                if (hitRight.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
                {
                    transform.position = hitRight.point;
                }
                else
                {
                    transform.position = eyes.right.GetPoint(3.0f);
                }
                break;
            case Fove.EFVR_Eye.Right:
                if (debug) Debug.Log("Left Eye: " + eyes.left.ToString());
                Physics.Raycast(eyes.left, out hitLeft, Mathf.Infinity);
                if (hitLeft.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
                {
                    transform.position = hitLeft.point;
                }
                else
                {
                    transform.position = eyes.left.GetPoint(3.0f);
                }
                break;
        }
	}
}
