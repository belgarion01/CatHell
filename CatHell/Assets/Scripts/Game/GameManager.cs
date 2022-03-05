using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    [SerializeField] private float _chaosByCat = 0.5f;
    [SerializeField] private float _timeBetweenTicks = 1f;
    
    private List<Cat> _catsInHouse = new List<Cat>();

    private float _chaosGauge;
    private float _maxChaosGauge = 100f;
    
    private float _tickTimer = 0f;

    public float MaxChaosGauge => _maxChaosGauge;
    public UnityEvent<float> OnChaosChanged;
    public UnityEvent OnGameOver;

    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
 
        _instance = this;

        _chaosGauge = _maxChaosGauge;
    }
    
    private void Update()
    {
        _tickTimer += Time.deltaTime;

        if (_tickTimer >= _timeBetweenTicks)
        {
            Tick();
            _tickTimer = 0f;
        }

        if (_chaosGauge <= 0f)
        {
            GameOver();
        }
    }

    private void Tick()
    {
        int numberOfMutatedCats = _catsInHouse.Count(x => x.Mutation.IsMutated);
        SubstractChaos(numberOfMutatedCats * _chaosByCat + 0.1f);
    }

    public void SetChaosGauge(float chaos)
    {
        float oldChaos = _chaosGauge;
        _chaosGauge = Mathf.Clamp(chaos, 0, _maxChaosGauge);

        if (!oldChaos.Equals(_chaosGauge))
        {
            OnChaosChanged?.Invoke(_chaosGauge);
        }
    }

    public void AddChaos(float chaosToAdd)
    {
        SetChaosGauge(_chaosGauge + chaosToAdd);
    }

    public void SubstractChaos(float chaosToSubstract)
    {
        SetChaosGauge(_chaosGauge - chaosToSubstract);
    }

    public void SubscribeCat(Cat cat)
    {
        _catsInHouse.Add(cat);
    }

    public void UnsubscribeCat(Cat cat)
    {
        _catsInHouse.Remove(cat);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
