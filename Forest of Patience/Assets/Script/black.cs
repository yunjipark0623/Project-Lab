using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black : MonoBehaviour {

    static GameObject blackscene;
    // Use this for initialization
    void Start () {
        blackscene = GameObject.FindWithTag("black");
        blackscene.SetActive(false);
    }

    //public void changeBlack(){
    //    blackscene.SetActive(true);
    //}
	
	// Update is called once per frame
	void Update () {
		
	}
}
