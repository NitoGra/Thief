using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
	[SerializeField] private Alarm _alarm;

	private void OnTriggerEnter(Collider thief)
	{
		if (thief.TryGetComponent<Patroul>(out Patroul patroul))
			_alarm.TurnOnSiren();
	}

	private void OnTriggerExit(Collider thief)
	{
		if (thief.TryGetComponent<Patroul>(out Patroul patroul))
			_alarm.TurnOffSiren();
	}
}