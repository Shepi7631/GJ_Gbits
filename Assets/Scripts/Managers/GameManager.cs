using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    private bool start = false;

    private int curCount = 0;
    private int playerCount = 0;

    private float minTimeGap = 5;
    private float maxTimeGap = 5;
    private float gap;
    private float timer;

    [SerializeField] private BoxCollider2D boxCollider;
    

    private void Start()
    {
        
    }
    public void GameStart()
    {
        start = true;
        gap = Random.Range(minTimeGap, maxTimeGap);
    }

    public void Spawn()
    {
        curCount++;
        gap = Random.Range(minTimeGap, maxTimeGap);
        Bounds bounds = boxCollider.bounds;
        Vector2 pos = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
            );


    }

    private void Update()
    {
        if (!start) return;
        timer += Time.deltaTime;
        if (timer >= gap) Spawn();
    }
}
