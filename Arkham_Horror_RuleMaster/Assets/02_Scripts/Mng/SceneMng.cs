using global_define;
using UnityEngine.SceneManagement;

public static class SceneMng
{
    public static Scene nowScene = null;
    public static LoadingScene loadingScene = null;

    public static eScene eNowScene = eScene.None;

    public static void ChangeScene(eScene _eScene)
    {
        nowScene = null;
        eNowScene = _eScene;
        SceneManager.LoadScene(eScene.Loading.ToDesc());
    }

    static public void LoadAddictiveScene(eScene _eScene)
    {
        SceneManager.LoadScene(_eScene.ToDesc(), LoadSceneMode.Additive);
    }

    public static void SetLoadingScene(LoadingScene _scene)
    {
        loadingScene = _scene;
    }

    public static void LoadAsync()
    {
        SceneManager.LoadSceneAsync(eNowScene.ToDesc());
    }

    static public void Regist(Scene scene)
    {
        nowScene = null;
    }
}
