using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigService
{
    MapData MapData {get;}
    UnitData[] UnitData {get;}
}

public class ConfigService : IConfigService
{
    public MapData MapData {get;}

    public UnitData[] UnitData {get;}

    public ConfigService(MapConfig mapConfig, UnitConfig unitConfig)
    {
        MapData = mapConfig.mapData;
        UnitData = unitConfig.unitDatas;
    }
}
