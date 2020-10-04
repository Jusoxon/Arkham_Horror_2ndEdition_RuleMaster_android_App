using UnityEngine;
using global_define;

public abstract class Scene : MonoBehaviour
{
    abstract public eScene eScene { get; }

    private void Awake()
    {
        SceneMng.Regist(this);
    }
}
