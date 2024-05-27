using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _scoreBall;
    public float _maxtime;
    private float _time;


    

    private void Update()
    {
        if(_time > _maxtime)
        {
            int rand = Random.Range(0, 10);

            if (rand < 7)
            {
                Instantiate(_ball, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_scoreBall, transform.position, Quaternion.identity);
            }

            _time = 0;
        }

        _time += Time.deltaTime; 
    }

}
