using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGlow : MonoBehaviour {

    public AudioClip note;
    private AudioSource source;
    private MeshRenderer[] mRends ;

    // Use this for initialization
    void Start () {
       
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cursor"))
        {
            mRends = GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer mRend in mRends)
            {
                if(mRend.gameObject.transform.parent != null)
                    mRend.enabled = true;
            }
            
            source = GetComponentInChildren<AudioSource>();
            if (source != null)
                source.PlayOneShot(note);
            
        }
       
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cursor"))
        {
            foreach (MeshRenderer mRend in mRends)
            {
                if (mRend.gameObject.transform.parent != null)
                    mRend.enabled = false;
            }
        }
       
    }
   
}
