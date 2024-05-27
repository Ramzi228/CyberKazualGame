using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;


public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText2;
    [SerializeField] private Text _recordText;
    



    private Text _scoreText;
    private Animator _animator;
    public static float _score;
    private float _record;
    private bool _isStarted;
    [HideInInspector] public int _set;

    private void Start()
    {
        _set = 0;
        Invoke(nameof(SetScore), 1f);
        _scoreText = GetComponent<Text>();
        _animator = GetComponent<Animator>();
        _record = PlayerPrefs.GetFloat("Record");
        YandexGame.NewLeaderboardScores("leaderboard", (int) _record);
    }

    private void SetScore()
    {
        _isStarted = true;
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("Record", _record);
        _recordText.text = _record.ToString();
        _scoreText.text = _score.ToString();
        _scoreText2.text = _score.ToString();

        if (_score > _record )
        {

            _record = _score;

        }


    }

    public void Animate()
    {
        _animator.SetTrigger("Play");
    }

    public void GetScore()
    {
        if (_isStarted)
        {
            _score ++;
        }
    }

    


}

