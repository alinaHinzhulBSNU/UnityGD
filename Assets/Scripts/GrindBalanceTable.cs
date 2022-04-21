using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class GrindBalanceData
{
    public Rank rank;
    public HOMode HOMode;
    public List<ItemModel> LocalEventGrindAward;
}

public enum HOMode
{
    Words,
    Silhouette,
    Abracadabra,
    Pictures,
    Difference
}

public enum Rank
{
    None,
    Rank1 = 1,
    Rank2 = 2,
    Rank3 = 3,
    Rank4 = 4,
    Rank5 = 5,
    Rank6 = 6,
    Rank7 = 7,
    Rank8 = 8,
}

[Serializable]
public struct ItemModel
{
    public string id;
    public float count;
}


[CreateAssetMenu(fileName = "GrindBalanceTable", menuName = "GrindBalanceTable")]
public class GrindBalanceTable : ScriptableObject
{
    [SerializeField]
    public List<GrindBalanceData> grindBalanceData;
}
