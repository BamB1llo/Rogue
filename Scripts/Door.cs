using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Alarm))]
public class Door : MonoBehaviour
{
    private bool _isInHouse; 

    public UnityAction<bool> WentThroughDoor;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _isInHouse = true;

            WentThroughDoor?.Invoke(_isInHouse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _isInHouse = false;

            WentThroughDoor?.Invoke(_isInHouse);
        }
    }
}
