using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject EcranTitre;
    public GameObject EcranJeu;
    public GameObject EcranQuit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (EcranTitre.activeSelf)
            {
                EcranTitre.SetActive(false);
                EcranJeu.SetActive(true);
                StartGame();
            }
            else if (EcranQuit.activeSelf)
            {
                EcranQuit.SetActive(false);
                EcranJeu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EcranJeu.activeSelf)
            {
                EcranJeu.SetActive(false);
                EcranQuit.SetActive(true);
            }
            else if (EcranQuit.activeSelf)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}
