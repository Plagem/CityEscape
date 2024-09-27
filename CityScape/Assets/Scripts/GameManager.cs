using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; //�̱��� ������ // �ܺο��� GameManager�� �����Ҷ� �̰� ����ٰ� ����
    [SerializeField] private GameObject settingSound;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject creditPanelButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject goToMenuButton;
    [SerializeField] private GameObject offSettingPanelButton;
    [SerializeField] private GameObject exitButton;
    public string roadMainMenu = "MainMenu";
    public static bool isMenu = true;
    public static bool isStage = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        if (isMenu == true && isStage == false)
        {
            continueButton.SetActive(false);
            restartButton.SetActive(false);
            goToMenuButton.SetActive(false);
            creditPanelButton.SetActive(true);
            offSettingPanelButton.SetActive(true);
            exitButton.SetActive(true);
        }
        else if (isMenu == false && isStage == true)
        {
            creditPanelButton.SetActive(false);
            offSettingPanelButton.SetActive(false);
            exitButton.SetActive(false);
            continueButton.SetActive(true);
            restartButton.SetActive(true);
            goToMenuButton.SetActive(true);
        }
    }
    public void OnExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OffPausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoMenuButton()
    {
        StartCoroutine(LoadMyAsyncScene());    
    }
    IEnumerator LoadMyAsyncScene()
    {
        // AsyncOperation�� ���� Scene Load ������ �� �� �ִ�.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(roadMainMenu);

        // Scene�� �ҷ����� ���� �Ϸ�Ǹ�, AsyncOperation�� isDone ���°� �ȴ�.
        while (!asyncLoad.isDone)
        {
            yield return null;
            isMenu = false;
            isStage = true;
        }
    }
}
