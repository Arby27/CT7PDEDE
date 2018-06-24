using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Globals : MonoBehaviour
    {

        public static Interation globalInteraction;
        public static DiceRay globalray;
        public static DiceCreate globalDiceCreate;
        public static int lastDiceRoll;

        public static bool[] statRollsEnabled = new bool[6];

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            statRollsEnabled[i] = true;
        }
    }

    private void Update()
        {
            globalray = Interation.grabbedObject.GetComponent<DiceRay>();
        }
    }

