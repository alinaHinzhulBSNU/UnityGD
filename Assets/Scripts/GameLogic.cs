using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Levels levels;

    // Start is called before the first frame update
    void Start()
    {
        levels.levelUp();
    }
}
