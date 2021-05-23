using System;
using System.Collections;
using System.Collections.Generic;
using Chronos;
using UnityEngine;

public class YeniPlayer : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    [SerializeField] public GlobalClock Clock;
    [SerializeField] private float moveSpeed = 10f;

    private PlayerInputSystem _playerInputSystem;

    private Rigidbody _rigidBody;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        _playerInputSystem = GetComponent<PlayerInputSystem>();
    }
    

    // Update is called once per frame
    private void Update()
    {
        _rigidBody.WakeUp();

        float yurumeHizi = 0;

        //ekrana dokunuyorsa yürü
        if (_playerInputSystem.GetScreenTouching)
            yurumeHizi = moveSpeed;

        var swerveAmount = Time.deltaTime * swerveSpeed * _playerInputSystem.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

        transform.Translate(swerveAmount, 0, yurumeHizi * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            Clock.localTimeScale = -1f;
        }
        else
        {
            Clock.localTimeScale = 1;
        }
        
        
    }
}
