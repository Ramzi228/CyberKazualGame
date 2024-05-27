using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;

    public YandexGame sdk;


    public void End()
    {
        Invoke(nameof(Set), 0.5f);
        
        Instantiate(_objects[5], _objects[3].transform.position, _objects[5].transform.rotation);
        Destroy(_objects[3].gameObject);

    }

    private void Set()
    {
        _objects[0].SetActive(false);
        _objects[1].SetActive(false);
        _objects[2].SetActive(true);

        Ball[] balls = GameObject.FindObjectsOfType<Ball>();
        if (balls.Length > 0)
        {
            foreach (var item in balls)
            {
                Destroy(item.gameObject);
            }
        }
    }

    public void Retry()
    {
        _objects[6].GetComponent<Score>()._set = 1;
        _objects[4].GetComponent<Animator>().SetTrigger("Show");
        Invoke(nameof(Load), 1f);
        YandexGame.FullscreenShow();
        Debug.Log("pokazal");

    }

    private void OnApplicationQuit()
    {
        _objects[6].GetComponent<Score>()._set = 1;
    }

    private void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score._score = 0;
    }

   public void Continued()
    {

    }

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }



    public void AdButtonCul()
    {

        Score._score += 15;
        _objects[6].GetComponent<Score>()._set = 1;
        _objects[4].GetComponent<Animator>().SetTrigger("Show");
        Invoke(nameof(Load), 1f);
    }

}
