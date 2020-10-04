using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;

public class LoadingScene : Scene
{
    public override eScene eScene { get { return eScene.Loading; } }

    public bool loadingFinish = false;

    private void Awake()
    {
        StartCoroutine(Loading());
        StartCoroutine(Async());

        Debug.Log("Scene Loading...");
        SceneMng.SetLoadingScene(this);
    }

    IEnumerator Loading()
    {
        while (loadingFinish == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Async()
    {
        yield return new WaitForSeconds(1.0f);
        SceneMng.LoadAsync();
    }
}
