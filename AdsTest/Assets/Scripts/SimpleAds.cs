using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class SimpleAds : MonoBehaviour
{
    void Start()
    {
        Application.runInBackground = true;

        Advertisement.Initialize("1038786", true);

        StartCoroutine(ShowAdWhenReady());
    }

    IEnumerator ShowAdWhenReady()
    {
        Debug.Log("Loading");
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
        Debug.Log("Ready");
    }
}