using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject[] _panels;

    

    private void Start()
    {
        _canvas.SetActive(false); 
    }

    public void WinCanvas()
    {

        _canvas.SetActive(true); 
        _panels[1].SetActive(false);
        _panels[0].SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseCanvas()
    {
        _canvas.SetActive(true); 
        _panels[0].SetActive(false);
        _panels[1].SetActive(true);
        Time.timeScale = 0f;
    }


    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
