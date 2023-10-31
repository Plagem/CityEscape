using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; //싱글톤 디자인 // 외부에서 GameManager에 접근할때 이걸 끌어다가 접근
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject audioPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void ShowAudioPanel()
    {
        audioPanel.SetActive(true);
    }
}
