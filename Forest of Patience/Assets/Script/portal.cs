using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour {

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
        if (other.gameObject.tag == "Player" && Scenename.Equals("Stage1")) change.GoToStage2();
        else if (other.gameObject.tag == "Player" && Scenename.Equals("Stage2")) change.GoToStage3();
        else if (other.gameObject.tag == "Player" && Scenename.Equals("Stage3")) change.GoToStage4();
        else if (other.gameObject.tag == "Player" && Scenename.Equals("Stage4"))
        {
            if(this.gameObject.name.Equals("house")){
                Debug.Log("ComeBack!");
                change.GoToEnding();
            }
            else
                change.GoToStage4();
        }


        // else if (other.gameObject.tag == "Player" && Scenename.Equals("Stage3")) change.GoToStage2();
    }
}
