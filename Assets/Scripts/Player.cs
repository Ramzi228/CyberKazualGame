using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class Player : MonoBehaviour
{
    
    [SerializeField] private float _border = 5f;
    private float _speed = 10f;
    private bool _isMoveUp;
    private bool _isMove = true;
    private EndGame _endGame;

    private void Start()
    {
        _endGame = FindObjectOfType<EndGame>();
        
        
    }

    private void Update()
    {
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -_border, _border), transform.position.z);

        if (_isMoveUp)
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }

        if (_isMove)
        {
            _speed = 10f;
        }
        else
        {
            _speed = 0;
        }
    }

    public void Move()
    {
        
        _isMove = true;
        _isMoveUp = !_isMoveUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            _isMove = false;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            _endGame.End();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            _isMove = true;
        }

    }
}
