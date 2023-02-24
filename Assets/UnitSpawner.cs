using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // this will allow us to use the Input controller

public class UnitSpawner : MonoBehaviour
{
    public Unit Spawn(Unit unitPrefab, Transform location)
    {
        // spawn and hod on to the component type
        Unit newUnit = Instantiate(unitPrefab,
            location.position, location.rotation);
        // TODO so setuop here if needed, spawn effects, etc. 
        return newUnit;
    }
}
