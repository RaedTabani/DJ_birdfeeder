using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ConfigModel 
{
    public string docId;
    public string version;
    public List<BuildingModel> buildings;

}

public class PlayerModel{
    public string docId;
    public string name;
    public DataModel data;
    public List<BuildingModel> buildings;
}

public class DataModel{

}
public class BuildingModel{

    
    public string assetId;
    public string spriteId;
    public string description;
    public int cost;
    public int level;
    public int amount;
    public int time;
    public Currency currency;
    public List<PropModel> upgrades;

}
public class PropModel{
    public string key;
    public string stringValue;
    public float floatValue;
    public int intValue;
    public Currency currencyValue;
}
public class MissionModel{
    public string assetId;
    public string name;
    public string description;
    public List<PropModel> subMissions;
}

public enum Currency{
    GOLD,
    FOOD,
    WOOD
}
