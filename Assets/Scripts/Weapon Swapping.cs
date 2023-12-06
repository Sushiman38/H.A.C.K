using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapping : MonoBehaviour
{

    [SerializedField] private int _weaponID;
    [SerializedField] private string _weaponName;
    private Renderer _cube;

    // Start is called before the first frame update
    void Start()
    {
        _cube = GetComponent<Renderer>();
        _weaponID = 0;
        _weaponName = "Pistol";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _weaponID = (_weaponID + 2) % 3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _weaponID = (_weaponID + 1) % 3;
        }
        switch (_weaponID)
        {
            case 0: //Mouse
                _cube.material.color = Color.cyan;
                _weaponName = "Mouse";
                break;
            case 1: //Shotgun
                _cube.material.color = Color.red;
                _weaponName = "Shotgun";
                break;
        }
    }
}
