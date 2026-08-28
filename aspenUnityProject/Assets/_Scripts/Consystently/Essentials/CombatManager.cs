using System;
using _Scripts.Runtime.Misc;
using Tether.CharacterSystems;
using UnityEngine;

namespace Consystently.Essentials
{
    /*will not be a traditional manager because it does not 
    need to be static. EncounterManager will be static and the one 
    to send the data over to CombatManager. CombatManager will exist
    in the battle scene only 
    */
    public class CombatManager : MonoBehaviour
    {
        //need to input data into the empty husk gameObjects 
        private UnitDataSO[,] initializerData;
        
        //used for instantiating the models
        private Encounter encounter; 
        
        //used for the actual unit logic 
        private readonly IUnitController[,] unitControllers =  new IUnitController[19, 4];
        
        //gets the transforms of the battle scene tiles. For determining player movements 
        //TODO: implement this and run on start
        private Transform[] tileTransforms; 
        
        void Start()
        {
            encounter = EncounterManager.Instance.GetEncounter();
            initializerData = EncounterManager.Instance.GetInitializerData();
            CreateObjects(); 
            ValidateData();
        }

        void CreateObjects()
        {
            for (int tile = 0; tile < encounter.TotalTiles(); tile++)
            {
                if (encounter.UnitCountAtTile(tile) < 1) 
                    continue; 
                for (int unit = 0; unit < encounter.MaxUnitsPerTile(); unit++)
                {
                    if (unit > encounter.UnitCountAtTile(tile) - 1)
                        break;
                    GameObject newTempObject = Instantiate(encounter[tile,unit], encounter[tile,unit].transform.position, Quaternion.identity);
                    
                    //set up controllers after object instantiation so they don't override each other
                    if(initializerData[tile,unit].Faction == Faction.Ally)
                        unitControllers[tile,unit] = newTempObject.GetComponent<AllyUnitController>();
                    else if (initializerData[tile,unit].Faction == Faction.Enemy)
                        unitControllers[tile,unit] = newTempObject.GetComponent<EnemyUnitController>();
                    else 
                        Debug.Log("neutral units not yet implemented");
                    unitControllers[tile, unit].Initialize(initializerData[tile,unit]);
                }
            }
        }
        

        //debug tool
        //TODO:
        //FINISH STAT SYSTEM; health will be at zero when printed
        //NOTE: currently, the most recently placed enemy will override 
        void ValidateData()
        {
            for (int tile = 0; tile < encounter.TotalTiles(); tile++)
            {
                if (encounter.UnitCountAtTile(tile) < 1) 
                    continue; 
                for (int unit = 0; unit < encounter.MaxUnitsPerTile(); unit++)
                {
                    if (unit > encounter.UnitCountAtTile(tile) - 1)
                        continue;
                    Debug.Log($"{unitControllers[tile,unit].GetData().Name}:  {unitControllers[tile,unit].GetData().Level}");
                    
                }
            }
        }
    }
}