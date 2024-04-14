using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Patroul : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private Transform _allPointsStorage;
	[SerializeField] private int _maxHalfCircle;

	private Animator _animator;
	private List<Transform> _allPoints;
	private Transform _point;
	private int _index;
	private bool _moveForward;
	private int _halfCircleCount;

	public void Start()
	{
		int skipPoints = 1;
		int speed = 2;
		_maxHalfCircle--;
		_animator = GetComponent<Animator>();
		_allPoints = _allPointsStorage.GetComponentsInChildren<Transform>().Skip(skipPoints).ToList();
		_index = 1;
		_point = _allPoints[_index];
		transform.LookAt(_point.position);
		_moveForward = true;
		_animator.SetInteger("Speed", speed);
	}

	public void Update()
	{
		if (_halfCircleCount > _maxHalfCircle)
		{
			_animator.SetInteger("Speed", 0);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

		if (transform.position == _point.position)
		{
			_point = TakeNextPlace();
			transform.LookAt(_point.position);
		}
	}

	private Transform TakeNextPlace()
	{
		int indexCount = _index + 1;

		if (indexCount == _allPoints.Count || _index <= 0)
		{
			_halfCircleCount++;
			_moveForward = !_moveForward;
		}

		if (_moveForward)
			_index++;
		else
			_index--;

		return _allPoints[_index];
	}
}