using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx 
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); }}


    public void LoadScene(Define.Scene type)
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);  //c#에서만 있는 reflection사용 c++은 안됨, enum값을 바로 넣는 다는 소리임
        return name;
    }
    public void Clear()
    {

    }
}
