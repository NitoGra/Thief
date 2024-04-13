using UnityEngine;

public class Alarm : MonoBehaviour
{
    private bool _isAlarmOn;
    private AudioSource _audio;
	private float _volumeChange = 0.0003f;
	private float _volumeMultiplier = 2;
	private float _alarmVolume = 0.002f;

	public void Start()
    {
		_audio = GetComponent<AudioSource>();
		_isAlarmOn = false;
	}

	public void Update()
    {
        if (_isAlarmOn)
            _audio.volume *= _volumeMultiplier;
        else
			_audio.volume -= _volumeChange;
	}

	private void OnTriggerEnter(Collider other)
	{
		_audio.Play();
		_audio.volume = _alarmVolume;
		_isAlarmOn = !_isAlarmOn;
	}

	private void OnTriggerExit(Collider other)
	{
		_isAlarmOn = !_isAlarmOn;
	}
}