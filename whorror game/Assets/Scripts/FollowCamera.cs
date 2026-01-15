using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject _gameObject;
    [SerializeField] float _cameraSpeed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y, -10), _cameraSpeed);
    }
}
