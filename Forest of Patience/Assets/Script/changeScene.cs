using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    public void GoToStage1(){
        SceneManager.LoadScene("Stage1");
    }

    public void GoToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void GoToStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void GoToStage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void GoToEnding(){
        SceneManager.LoadScene("Ending");
    }
}
