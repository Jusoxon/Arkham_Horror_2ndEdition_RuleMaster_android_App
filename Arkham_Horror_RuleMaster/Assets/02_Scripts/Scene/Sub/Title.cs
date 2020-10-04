using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;

public class Title : Scene
{
    public override eScene eScene { get { return eScene.Title; } }

    private void Start()
    {
        PlayersMng.Init();
        GameMng.Init();
    }
}
