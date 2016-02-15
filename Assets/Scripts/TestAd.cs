using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class TestAd : MonoBehaviour
{
    [SerializeField]
    string gameID = "1038785";

    void Awake()
    {
        Application.runInBackground = true;
        Advertisement.Initialize(gameID, true);

        StartCoroutine(iShowAd());
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    ShowAd();
        //}
    }

    public void ShowAd(string zone = "")
    {
        Debug.Log("Show");
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }

    void AdCallbackhandler(ShowResult result)
    {
        Debug.Log("Callback");
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished. Rewarding player...");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }

        StartCoroutine(iShowAd());
        
    }

    IEnumerator iShowAd()
    {
        yield return new WaitForSeconds(5);
        ShowAd();
    }

    IEnumerator WaitForAd()
    {
        Debug.Log("Wait for ad");
        float currentTimeScale = Time.timeScale;
        //Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
        {
            yield return null;
        }

        Time.timeScale = currentTimeScale;
    }
}