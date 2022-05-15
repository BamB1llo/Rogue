using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AlarmSystem))]
public class Door : MonoBehaviour
{
    public UnityAction WalkedInTheDoor;
    public UnityAction WalkedOutOfTheDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            WalkedInTheDoor?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            WalkedOutOfTheDoor?.Invoke();
        }
    }
}
