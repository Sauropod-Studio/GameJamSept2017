using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject EcranTitre;
    public GameObject EcranJeu;
    public GameObject EcranQuit;
    public float DelaiAffichagePourJeu = 10f;

    private float _delai;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (EcranTitre.activeSelf)
            {
                EcranTitre.SetActive(false);
                EcranJeu.SetActive(true);
                StartGame();
                _delai = DelaiAffichagePourJeu;
            }
            else if (EcranQuit.activeSelf)
            {
                EcranQuit.SetActive(false);
                if (_delai > 0)
                    EcranJeu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!EcranTitre.activeSelf && !EcranQuit.activeSelf)
            {
                EcranJeu.SetActive(false);
                EcranQuit.SetActive(true);
            }
            else if (EcranQuit.activeSelf)
            {
                EcranTitre.SetActive(true);
                EcranQuit.SetActive(false);
                LeaveGame();
            }
        }

        if (_delai > 0)
        {
            _delai -= Time.deltaTime;
            if (_delai <= 0)
                EcranJeu.SetActive(false);
        }
    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    void LeaveGame()
    {
        SceneManager.UnloadSceneAsync(1);
        /*                Application.Quit();
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #endif*/
    }
}
