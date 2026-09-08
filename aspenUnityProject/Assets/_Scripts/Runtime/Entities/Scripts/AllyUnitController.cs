using System;
using Tether.CharacterSystems;
using UnityEngine;

//this script must be dragged to an object before making it a prefab and dragging the prefab to a unit SO.
public class AllyUnitController : UnitController {
   private AllyUnit stats;
   public Vector3Int TileCoords {get; private set;}

   //to be called by the combat maanager 
   public override void Initialize(UnitDataSO baseStats)
   {
      stats = new AllyUnit(baseStats);
   }

   /*
    TODO:
    add movement that is disabled on combat game state  
   */
   private void Update()
   {
      
   }

   public override void TakeDamage(int damage)
   {
      stats?.ChangeHealthRemaining(damage); 
   }

   //will differ from SetTile in that it will consider game logic with conditionals 
   public override void Move(Vector3Int newTileCoords)
   {
   }

   public override void Move(Vector3 position)
   {
     transform.position = position; 
   }
   
   public override Unit GetData()
   {
      return stats; 
   }

   public override Vector3Int GetTileCoords()
   {
      return TileCoords;
   }

   public override void SetTile(Vector3Int newTileCoords)
   {
      this.TileCoords = newTileCoords;
   }
}
