using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : ScriptableObject
{
    public const string MENU_PATH = "Tools/";
    
    [SerializeField] public Sprite Sprite;
    [SerializeField] public string Name;
    public abstract void OnUseDown(GameObject player);
    public abstract void OnTick(GameObject player);
    public abstract void OnUseUp(GameObject player);
    public abstract void OnEquip(GameObject player);
}
