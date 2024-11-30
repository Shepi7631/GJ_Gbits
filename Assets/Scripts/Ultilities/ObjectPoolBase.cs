using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolBase<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    private ObjectPool<T> pool;

    public int ActiveCount => pool.CountActive;
    public int InActiveCount => pool.CountInactive;
    public int TotalCount => pool.CountAll;
    protected void Awake()
    {
        Init();
    }
    protected void Init() =>
        pool = new ObjectPool<T>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    protected virtual T CreateFunc() => Instantiate(prefab, transform);
    protected virtual void ActionOnGet(T obj) => obj.gameObject.SetActive(true);
    protected virtual void ActionOnRelease(T obj) => obj.gameObject.SetActive(false);
    protected virtual void ActionOnDestroy(T obj) => Destroy(obj.gameObject);
    public T Get => pool.Get();
    public void Release(T obj) => pool.Release(obj);
    public void Clear() => pool.Clear();
}
