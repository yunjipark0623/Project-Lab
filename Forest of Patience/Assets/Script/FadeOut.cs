using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public float aniTime = 2f;
    private Image fadeOut;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private bool isPlaying = false;
    // Use this for initialization

    private void Awake()
    {
        fadeOut = GetComponent<Image>();
    }

    public void StartFadeOut(){
        if (isPlaying == true)
            return;
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeOut(){
        isPlaying = true;
        Color color = fadeOut.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while(color.a<1f){
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeOut.color = color;

            yield return null;

        }
        isPlaying = false;
    }
}
