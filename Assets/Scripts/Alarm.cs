using UnityEngine;

public class Alarm : MonoBehaviour
{
	private bool _isAlarmOn;
	private AudioSource _audio;
	private float _volumeDecreases = 0.008f;
	private float _volumeIncreases = 0.008f;
	private float _startVolume = 0.0002f;

	public void Start()
	{
		_audio = GetComponent<AudioSource>();
		_isAlarmOn = false;
	}

	public void Update()
	{
		if (_isAlarmOn)
			_audio.volume += _volumeIncreases;
		else
			_audio.volume -= _volumeDecreases;
	}

	private void OnTriggerEnter(Collider other)
	{
		_audio.Play();
		_audio.volume = _startVolume;
		_isAlarmOn = !_isAlarmOn;
	}

	private void OnTriggerExit(Collider other)
	{
		_isAlarmOn = !_isAlarmOn;
	}
}