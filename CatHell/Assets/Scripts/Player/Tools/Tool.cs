using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : ScriptableObject
{
    public const string MENU_PATH = "Tools/";
    
    [SerializeField] public Sprite Sprite;
    public abstract void OnUseDown(GameObject player);
    public abstract void OnTick(GameObject player);
    public abstract void OnUseUp(GameObject player);
}
