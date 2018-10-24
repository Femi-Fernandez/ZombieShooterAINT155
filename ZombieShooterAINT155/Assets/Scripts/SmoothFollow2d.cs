using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2d : MonoBehaviour {
    public Transform target;
    public float smoothing = 5.0f;
    // Use this for initialization
    void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 NewPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, NewPos, (smoothing * 0.001f));
	}
}
