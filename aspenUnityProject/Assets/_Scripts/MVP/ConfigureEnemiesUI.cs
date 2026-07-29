using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ConfigureEnemiesUI : MonoBehaviour
{
  [SerializeField] private List<UnitButtonUI> _enemyButtons;
  public Stack<UnitButtonUI> EnemyButtons = new Stack<UnitButtonUI>();

  private UnitDataSO _hoveredEnemyData, _selectedEnemyData;
  
  private void Awake()
  {
    // Alphabetize and reverse the order of the enemy buttons, then put them into a stack
    foreach(UnitButtonUI unitButton in _enemyButtons.OrderByDescending(x => x.gameObject.name))
      EnemyButtons.Push(unitButton);
  }

  public void AddEnemy()
  {
    
  }

  public void DuplicateEnemy()
  {
    
  }

  public void RemoveEnemy()
  {
    
  }
}
