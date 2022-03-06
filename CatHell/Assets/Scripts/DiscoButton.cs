
using TMPro;
using UnityEngine;

public class DiscoButton : MonoBehaviour, IInteractable
{
    private float _timerDiscoCooldown;
    public float TimerDiscoCooldown
    {
        get
        {
            return _timerDiscoCooldown;
        }
        set
        {
            _timerDiscoCooldown = value;
            if (TimerDiscoCooldown == 0)
            {
                
            }
          
            else if (TimerDiscoCooldown >= _timeDiscoCooldown)
            {
                
            }

            else
            {
                
            }
           
            
        }
    }
    [SerializeField]
    float _timeDiscoCooldown;
    
    public void Interact(GameObject user)
    {
        if(TimerDiscoCooldown >= _timeDiscoCooldown)
            GameManager.Instance.SetDiscoEnabled(true);
            
    }
    private void Update()
    {
        if (TimerDiscoCooldown < _timeDiscoCooldown && !GameManager.Instance.InDisco)
        {
            TimerDiscoCooldown += Time.deltaTime;
        }
        
    }

    [SerializeField]
    private string _DiscoName;
    public string ActionName => _DiscoName; 
}
