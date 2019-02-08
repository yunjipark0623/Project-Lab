using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        string Scenename = SceneManager.GetActiveScene().name;

        changeScene change = new changeScene();
        if (other.gameObject.tag == "Player" && Scenename.Equals("Stage4")) change.GoToStage4();
    }
}
