using UnityEngine;

[RequireComponent(typeof(AlarmSystem))]
public class Door : MonoBehaviour
{
    private AlarmSystem _alarmSystem;

    private void Start()
    {
        _alarmSystem = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _alarmSystem.IncreaseVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _alarmSystem.DecreaseVolume();
        }
    }
}
