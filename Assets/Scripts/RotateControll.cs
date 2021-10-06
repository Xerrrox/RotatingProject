using UnityEngine;

public class RotateControll : MonoBehaviour
{
    private Vector2 _startPos;
    private bool _isFingerDown;
    private int _pixelDistanceToDetect = 10;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    Rotate(90f);
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                Rotate(90f);
        }

        if (_isFingerDown == false && Input.touchCount > 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            _startPos = Input.touches[0].position;
            _isFingerDown = true;
        }

        if (_isFingerDown)
        {
            //Swipe right
            if (Input.touches[0].position.x >= _startPos.x + _pixelDistanceToDetect)
            {
                Rotate(90f);
                _isFingerDown = false;
            }
            //Swipe left
            else if (Input.touches[0].position.x <= _startPos.x - _pixelDistanceToDetect)
            {
                Rotate(-90f);
                _isFingerDown = false;
            }
        }
    }

        private void Rotate(float angle)
    {
        transform.Rotate(new Vector3(0, 90, 0), angle);
    }
}
