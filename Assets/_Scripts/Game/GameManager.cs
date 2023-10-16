using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GlobalReference<GameManager>
{
    [Serializable]
    public class GameStatus
    {
        public const string FILE_NAME = "GameStatus";

        public int gold;
    }
    private static readonly GameStatus _status = new();
    public static event Action OnGoldChange;
    public static int PlayerGold
    {
        get => _status.gold;
        set
        {
            if (value <= 0)
                value = 0;

            _status.gold = value;
            OnGoldChange?.Invoke();
        }
    }
}
