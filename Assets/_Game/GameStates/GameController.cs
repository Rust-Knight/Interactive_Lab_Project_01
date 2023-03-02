using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour // store data needed for SetupGame to do its job 
{

    [Header("Game Data")] // this is our lose condition 
    [SerializeField] private float _loseCondition = 2.5f; // designer control what the ‘duration’ should be 

    [Header("Dependencies")]
    [SerializeField] private Unit _playerUnitPrefab;
    [SerializeField] private Transform _playerUnitSpawnLocation;
    [SerializeField] private UnitSpawner _unitSpawner;/* Because we’re going to ask the UnitSpawner to .Spawn() things in our states, we need to hold on to a public
                                                             reference to it in our GameController. */
    [SerializeField] private InputBroadcaster _input; // InputBroadcaster

    public float LoseCondition => _loseCondition;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public InputBroadcaster Input => _input; // InputBroadcaster



    /*
    [field: SerializeField] public float LoseCondition 
    {get; private set; } = 2.5f; 

    [field: SerializeField]
    public Unit PlayerUnitPrefab { get; private set; }
    [field: SerializeField]
    public Transform PlayerUnitSpawnLocation { get; private set; }

    [field: SerializeField]
    public UnitSpawner UnitSpawner { get; private set; } 

    [field: SerializeField]
    public InputBroadcaster Input { get; private set; }
    */
}
