using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Door _door;

    private Coroutine _changeVolume;
    private AudioSource _audioSource;
    private float _maximumVolume = 1;
    private float _minimumVolume = 0;
    private float _duration = 0.1f;

    private void OnEnable()
    {
        _door.WentThroughDoor += OnWenhThroughDoor;
    }

    private void OnDisable()
    {
        _door.WentThroughDoor -= OnWenhThroughDoor;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void GetVolume(float volume)
    {
        _changeVolume = StartCoroutine(ChangeVolume(volume));
        _audioSource.Play();
    }

    private void OnWenhThroughDoor(bool isInOpen)
    {
        if (isInOpen == true)
        {
            GetVolume(_maximumVolume);
        }
        else
        {
            StopCoroutine(_changeVolume);
            GetVolume(_minimumVolume);
        }
    }

    private IEnumerator ChangeVolume(float finalValue)
    {
        while (_audioSource.volume != finalValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finalValue, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
