using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponType{
    none,
    blaster,
    spread,
    phaser,
    missile,
    laser,
    shield

}
///<summary>
///Класс WeaponDefinition позволяет настраивать свойства конкретного вида оружия в инспекторе
///Для этого класс Main бдет хранить массив элементов типа Weapondefinition.
///</summary>
[System.Serializable]
public class WeaponDefinition{
    public WeaponType type = WeaponType.none;
    public string letter;

    public Color color = Color.white;
    public GameObject projectilePrefab;
    public Color projectileColor = Color.white;
    public float damageOnHit = 0;
    public float continuosDaamage = 0;

    public float delayBetweenShots = 0;
    public float velocity = 20;
}


public class Weapon : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
