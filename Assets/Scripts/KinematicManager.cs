using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kinematic"))
            other.gameObject.transform.root.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Kinematic"))
            other.gameObject.transform.root.GetComponent<Rigidbody>().isKinematic = true;
    }
}
