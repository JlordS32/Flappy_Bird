using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    // CONSTANTS
    public const float MIN_DELAY = 1f;

    // Properties
    [SerializeField] List<GameObject> _objectPrefabs;
    [SerializeField] float _minY;
    [SerializeField] float _maxY;

    [Header("Delay")]
    [SerializeField] bool _enableRandomDelay;
    [Min(MIN_DELAY)]
    [SerializeField] float _delay;

    void Start()
    {
        StartCoroutine(nameof(SpawnObjects));
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Randomly pool objects from the prefab list
            GameObject objectPrefab = _objectPrefabs[Random.Range(0, _objectPrefabs.Count)];

            // Get spawn position
            Vector3 spawnPos = new(transform.position.x, Random.Range(_minY, _maxY), 0f);
            Instantiate(objectPrefab, spawnPos, Quaternion.identity, transform);

            yield return new WaitForSeconds(_enableRandomDelay ? Random.Range(MIN_DELAY, _delay) : Mathf.Max(MIN_DELAY, _delay));
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 top = new(transform.position.x, transform.position.y + _maxY, 0f);
        Vector3 bottom = new(transform.position.x, transform.position.y + _minY, 0f);
        Gizmos.DrawLine(top, bottom);
    }
}
