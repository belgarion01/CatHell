
using Shapes;
using TMPro;
using UnityEngine;

public class DiscoButton : MonoBehaviour, IInteractable
{
    private float _timerDiscoCooldown;
    [SerializeField] float _timeDiscoCooldown;
    [SerializeField] private Disc _discCooldown;
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
                _discCooldown.Color = Color.magenta;
            }
          
            else if (TimerDiscoCooldown >= _timeDiscoCooldown)
            {
                _discCooldown.Color = Color.green;
            }

            else
            {
                _discCooldown.Color = Color.red;
            }
        }
    }

    
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

        _discCooldown.AngRadiansEnd = Mathf.Lerp(0f, Mathf.Deg2Rad * 360f, Mathf.InverseLerp(0, _timeDiscoCooldown, _timerDiscoCooldown));
        Debug.Log(Mathf.Lerp(0f, Mathf.Deg2Rad * 360f, Mathf.InverseLerp(0, _timeDiscoCooldown, _timerDiscoCooldown)));
    }

    [SerializeField]
    private string _DiscoName;
    public string ActionName => _DiscoName; 
}
