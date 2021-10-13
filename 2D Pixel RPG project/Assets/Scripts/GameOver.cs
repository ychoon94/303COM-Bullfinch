using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string mainMenuScene;
    public string loadGameScene;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(4);
        GameMenu.instance.allowMenuToOpen = false;

        /*PlayerController.instance.gameObject.SetActive(false);
        GameMenu.instance.gameObject.SetActive(false);
        BattleManager.instance.gameObject.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitToMain()
    {
        Destroy(GameManager.instance.gameObject);
        Destroy(PlayerController.instance.gameObject);
        Destroy(GameMenu.instance.gameObject);
        Destroy(AudioManager.instance.gameObject);
        Destroy(BattleManager.instance.gameObject);
        GameMenu.instance.allowMenuToOpen = true;

        SceneManager.LoadScene(mainMenuScene);
    }

    public void LoadLastSave()
    {
        Destroy(GameManager.instance.gameObject);
        Destroy(PlayerController.instance.gameObject);
        Destroy(GameMenu.instance.gameObject);
        GameMenu.instance.allowMenuToOpen = true;

        //Destroy(BattleManager.instance.gameObject);

        SceneManager.LoadScene(loadGameScene);
    }
}
