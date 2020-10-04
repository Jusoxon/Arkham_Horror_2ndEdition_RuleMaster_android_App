using global_define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : Scene
{
    public override eScene eScene { get { return eScene.Start; } }

    public GameObject teamLogo;

    private void Start()
    {
        DataMng.Init();
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneMng.ChangeScene(eScene.Title);
    }
}
