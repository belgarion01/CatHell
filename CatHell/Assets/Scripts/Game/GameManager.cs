using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
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
    [SerializeField] private MeshRenderer _discoFloor;
    [SerializeField] private VolumeProfile _defaultVolume;
    [SerializeField] private VolumeProfile _discoVolume;
    [SerializeField] private Volume _sceneVolume;
    [SerializeField] private TextMeshProUGUI _savedCatsTextMesh;

    
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
    [SerializeField] private GameObject _catPrefab;

[SerializeField] private float _timeSpawn;
private float _timerSpawn;
[SerializeField]
private List<Material> _catSkinList;

float _timerDisco;
[SerializeField]
float _timeDisco;

public bool InDisco;

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

        if (InDisco)
        {
            if (_timeDisco > _timerDisco)
                _timerDisco += Time.deltaTime;
            else SetDiscoEnabled(false);
        }
    }
    public void Launch()
    {
        foreach (Cat cat in CatsInHouse)
        {
            cat.Machine.enabled = false;
            cat.Agent.isStopped = true;
            cat.Agent.enabled = false;
        }
        InDisco = true;
    }
    
   private bool CheckSpawnCat()
    {
        if (_timeSpawn > _timerSpawn)
        {
            _timerSpawn += Time.deltaTime;
            return false;
        }
        _timerSpawn = 0;
        return true;
    }
   
  private void SpawnCat()
    {
        int rand = Random.Range(0, DestinationCat.instance.spawnerCatList.Length);
        int rand2 = Random.Range(0, _catSkinList.Count);
        
        GameObject currentCat = Instantiate(_catPrefab, DestinationCat.instance.spawnerCatList[rand].position, Quaternion.identity);
        currentCat.GetComponent<Cat>().SkinnedMeshRenderer.material = _catSkinList[rand2];
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
        _savedCatsTextMesh.text = $"You save {_catsInHouse.Count} cats!";
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
        foreach (Cat cat in CatsInHouse)
        {
            if (!cat.IsHeld)
            {
                if (enable)
                {
                  
                    cat.Agent.isStopped = enable;
                    cat.Agent.enabled = !enable;
                }
                    else
                { 
                    cat.Agent.enabled = !enable;
                    cat.Agent.isStopped = enable;
                }
                cat.Machine.enabled = !enable;
            }
            
            cat.AnimSetDisco(enable);
        }
        InDisco = enable;
        _audioSource.clip = enable ? _discoMusic : _defaultMusic;
        _audioSource.Play();
        _discoFloor.material.SetInt("_Disconight", enable ? 0 : 1);
        _sceneVolume.profile = enable ? _discoVolume : _defaultVolume;
        OnDiscoChanged?.Invoke(enable);
    }

    [Button]
    public void Disco()
    {
        SetDiscoEnabled(true);
    }
}
