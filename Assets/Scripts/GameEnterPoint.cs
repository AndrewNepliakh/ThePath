using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameEnterPoint : MonoBehaviour
{
    private void Awake()
    {
        UserManager.Init(SaveManager.Load());
    }
}
