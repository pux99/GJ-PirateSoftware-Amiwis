using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(sceneName);
    }
}
