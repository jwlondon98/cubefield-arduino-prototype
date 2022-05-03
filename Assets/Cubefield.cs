using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Cubefield : MonoBehaviour
{
    #region Declarations

    public GameObject cube;
    public Collider spawnerCollider;
    private Bounds bounds;

    public Rigidbody playerRB;

    public Vector2 cubeAmountRange;
    public int rangeAbsoluteMax;
    public float minFactor;
    public float maxFactor;

    public float timeAlive;

    public float delay;

    public List<Color> colors = new List<Color>();

    #endregion  

    #region Unity Methods

    private void Awake()
    {
        bounds = spawnerCollider.bounds;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (Time.time > delay)
            timeAlive = Time.time - delay;
    }

    #endregion  

    #region Custom Methods

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);

        var amt = Mathf.RoundToInt(Random.Range(cubeAmountRange.x, cubeAmountRange.y));
        for (int i = 0; i < amt; i++)
        {
            var canSpawn = Random.Range(0, 100) % 2 == 0;
            if (!canSpawn)
                continue;

            var x = Random.Range(bounds.min.x, bounds.max.x);
            var pos = new Vector3(x, 0, transform.position.z);

            if (playerRB.velocity.magnitude > 0)
            {
                var color = colors[Random.Range(0, 2)];
                var cubeComp = Instantiate(cube, pos, Quaternion.identity, null).GetComponent<Cube>();
                cubeComp.SetColor(color);
            }
        }

        if (cubeAmountRange.y < rangeAbsoluteMax)
        {
            cubeAmountRange = new Vector2(
                cubeAmountRange.x + (timeAlive * minFactor),
                cubeAmountRange.y + (timeAlive * maxFactor));
        }

        StartCoroutine(Spawn());
    }

    #endregion  
}
