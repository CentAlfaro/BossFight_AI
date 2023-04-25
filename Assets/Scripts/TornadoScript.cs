using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TornadoScript : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;

    private bool _isTimerRunning;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("player").transform;
        StartCoroutine(TornadoDuration());
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _player.position;
    }

    private IEnumerator TornadoDuration()
    {
        if (!_isTimerRunning)
        {
            _isTimerRunning = true;
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
            _isTimerRunning = false;
        }
    }
}
