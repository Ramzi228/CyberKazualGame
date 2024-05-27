using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _decreaseTime;
    private float _force = -300;
    private float _direction = 1f;
    private float _lifeTime = 5f;
    public bool _scoreBall;
    private Score _score;
    private Spawner _spawner;

    private void Start()
    {
        

        _spawner = FindObjectOfType<Spawner>();

        _score = FindObjectOfType<Score>();

        _spawner._maxtime -= _decreaseTime * Time.deltaTime;

        int rand = Random.Range(0, 10);

        if(rand < 5)
        {
            _force = 300f;
            _direction = -1f;

        }
        else if(rand > 5)
        {
            _force = -300f;
            _direction = 1f;
        }
        AddForce();
        Destroy(gameObject, _lifeTime);

        

    }

    private void AddForce()
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.AddForce(new Vector2(_direction * (_force / 2), _force));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && _scoreBall)
        {
            Destroy(gameObject);
            _score.Animate();
        }
    }
}
