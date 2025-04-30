using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext
{
    private static ProjectContext instance;

    public static ProjectContext Instance
    {
        get{
            if(instance == null)
            instance = new ProjectContext();
            return instance;
        }
    }

    public IConfigService ConfigService {get; private set;}
    public IMapService MapService {get; private set;}

    public void Initialize(MapConfig mapConfig)
    {
        ConfigService = new ConfigService(mapConfig);
        MapService = new MapService(ConfigService);
        Debug.Log("Loaded successfully");
    }
}
