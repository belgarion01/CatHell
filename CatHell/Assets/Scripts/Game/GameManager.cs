using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    [SerializeField] private float _chaosByCat = 0.5f;
    [SerializeField] private float _timeBetweenTicks = 1f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _discoMusic;

    
    private List<Cat> _catsInHouse = new List<Cat>();
    public List<Cat> CatsInHouse => _catsInHouse;
    public int MutatedCatsInHouse => _catsInHouse.Count(x => x.Mutation.IsMutated);

    private float _chaosGauge;
    private float _maxChaosGauge = 100f;
    
    private float _tickTimer = 0f;

    private bool _isGamePaused = false;

    public float MaxChaosGauge => _maxChaosGauge;
    public bool IsGamePaused => _isGamePaused;
    public UnityEvent<float> OnChaosChanged;
    public UnityEvent OnGameOver;
    public UnityEvent<bool> OnDiscoChanged;
    [SerializeField] private GameObject catPrefab;

[SerializeField] private float timeSpawn;
private float timerSpawn;

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
        if(CheckSpawnCat())
            SpawnCat();
        
    }

    public bool CheckSpawnCat()
    {
        if (timeSpawn > timerSpawn)
        {
            timerSpawn += Time.deltaTime;
            return false;
        }
        timerSpawn = 0;
        return true;
    }
    public void SpawnCat()
    {
        int rand = Random.Range(0, DestinationCat.instance.spawnerCatList.Length);
        Instantiate(catPrefab, DestinationCat.instance.spawnerCatList[rand].position, Quaternion.identity);
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
        _isGamePaused = true;
        OnGameOver?.Invoke();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetDiscoEnabled(bool enable)
    {
        _audioSource.clip = enable ? _discoMusic : _defaultMusic;
        _audioSource.Play();
        
        OnDiscoChanged?.Invoke(enable);
    }
}
