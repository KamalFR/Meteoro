using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnPoints;

    [SerializeField]
    private GameObject[] defaultMeteors;
    [SerializeField]
    private GameObject[] meteorosTeleguiados;
    [SerializeField]
    private GameObject[] meteorosArmados;

    private GameObject[] meteorsAllowedToSpawn;

    public enum SpecialEvent
    {
        NONE,
        CHUVA_DE_METEORO,
        METEOROS_ARMADOS,
        METEOROS_TELEGUIADOS
    };
    private SpecialEvent currentEvent = SpecialEvent.NONE;
    public SpecialEvent CurrentEvent => currentEvent;


    private void OnEnable()
    {
        TimeManager.OnEventTriggered += ChangeCurrentEvent;
    }

    private void OnDisable()
    {
        TimeManager.OnEventTriggered -= ChangeCurrentEvent;
    }

    private void Start()
    {
        meteorsAllowedToSpawn = defaultMeteors;
        ChangeNextEvent();
    }

    public void NormalEvent()
    {
        currentEvent = SpecialEvent.NONE;
    }
    public void ChangeNextEvent()
    {
        var rng = Random.Range(0, 3);

        switch (rng)
        {
            case 0:
                currentEvent = SpecialEvent.CHUVA_DE_METEORO;
                break;
            case 1:
                currentEvent = SpecialEvent.METEOROS_ARMADOS;
                break;
            case 2:
                currentEvent = SpecialEvent.METEOROS_TELEGUIADOS;
                break;
        }

        //OneventChangeUI.invoke(event)
        //OneventChangeBackgroundDefault.invoke(event)

    }

    public void ChangeCurrentEvent()
    {
        switch (currentEvent)
        {
            case SpecialEvent.NONE:
                meteorsAllowedToSpawn = defaultMeteors; break;
            case SpecialEvent.METEOROS_ARMADOS:
                meteorsAllowedToSpawn = defaultMeteors.Concat(meteorosArmados).ToArray(); break;
            case SpecialEvent.METEOROS_TELEGUIADOS:
                meteorsAllowedToSpawn = defaultMeteors.Concat(meteorosTeleguiados).ToArray(); break;
            case SpecialEvent.CHUVA_DE_METEORO:
                meteorsAllowedToSpawn = defaultMeteors; break;
        }

        //OneventChangeBackground.invoke(event)

    }

    public void MeteorLevelIncrese()
    {
        meteorsAllowedToSpawn = defaultMeteors;
        ChangeNextEvent();
    }

    public void SpawnNewMeteor()
    {
        int spawn = Random.Range(0, _spawnPoints.Length);
        var meteor = Random.Range(0, meteorsAllowedToSpawn.Length);
        Instantiate(meteorsAllowedToSpawn[meteor], _spawnPoints[spawn].position, Quaternion.identity);
    }

    private float currentTime = 0f;

    [SerializeField] private float _meteorSpawnCooldown;
    [SerializeField] private float _meteorRainSpawnCooldown;
    [SerializeField] private float _multiplicativeSpawnCooldown;
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < _meteorSpawnCooldown)
            return;

        currentTime = 0f;
        SpawnNewMeteor();

    }

}
