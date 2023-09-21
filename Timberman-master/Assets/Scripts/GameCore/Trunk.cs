using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trunk : MonoBehaviour
{
    public string direction;
    private float _target;
    private float _velocity;
    private float _totalTime = 1.0f;
    private float _currentTime;
    private bool _isAnimating = false;
    
    
    private void Update()
    {
        if (!_isAnimating) { return; }

        _currentTime += Time.deltaTime;
        
        var o = gameObject;
        var localPosition = o.transform.localPosition;
         localPosition =
             new Vector3(localPosition.x + (_velocity * _currentTime),
                 localPosition.y, localPosition.z);
         o.transform.localPosition = localPosition;
         o.transform.Rotate(Vector3.forward,5f,Space.Self);

        //transform.DOJump(localPosition, 0.1f, 1, 0.3f);
        o.transform.localPosition = localPosition;

        if (_currentTime >= _totalTime)
        {
            Destroy(gameObject);
            _isAnimating = false;
        }
    }

    // public void PlayJumpTrunk(string playerDirection)
    // {
    //     _target = (playerDirection == "RIGHT") ? -5 : 5;
    //     _velocity = (_target - gameObject.transform.localPosition.x) / _totalTime;
    //     _isAnimating = true;
    // }
    public void PlayDestroyAnimation(string playerDirection)
    {
        _target = (playerDirection == "RIGHT") ? -5 : 5;
        _velocity = (_target - gameObject.transform.localPosition.x) / _totalTime;
        _isAnimating = true;
    }
}