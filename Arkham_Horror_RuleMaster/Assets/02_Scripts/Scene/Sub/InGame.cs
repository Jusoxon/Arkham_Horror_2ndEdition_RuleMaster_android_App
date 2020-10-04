using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;

public class InGame : Scene
{
    public override eScene eScene { get { return eScene.InGame; } }

    private void Start()
    {
        RuleMaster.Ins.Init();
    }
}
