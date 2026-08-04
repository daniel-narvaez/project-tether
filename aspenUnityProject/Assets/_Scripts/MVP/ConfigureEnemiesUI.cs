using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Consystently.UI;
using UnityEngine.EventSystems;

public class ConfigureEnemiesUI : MonoBehaviour
{
  [SerializeField] private UnitDetailsUI _unitDetailsPanel;
  [SerializeField] private GameObject catalogButtonPrefab;
  [SerializeField] private List<UnitSim> _enemySims;

  public Stack<UnitSim> VacantEnemyButtons { get; private set; } = new Stack<UnitSim>();
  public List<UnitSim> ActiveEnemyButtons { get; private set; } = new List<UnitSim>();

  private UnitDataSO _hoveredEnemyData, _selectedEnemyData;
  private Dictionary <ButtonVE, EnemyUnitSO> _catalogButtons = new Dictionary<ButtonVE, EnemyUnitSO>();

  
  private void Awake()
  {
    // Alphabetize and reverse the order of the enemy buttons, then put them into a stack
    foreach(UnitSim sim in _enemySims.OrderByDescending(x => x.gameObject.name))
    {
      sim.gameObject.SetActive(false);
      VacantEnemyButtons.Push(sim);
    }
  }

  private void Start()
  {
    List<EnemyUnitSO> enemyUnits = EnemyCatalog.Instance.Objects;
    PopulateEnemyList(enemyUnits);
  }

  private void PopulateEnemyList(List<EnemyUnitSO> enemyUnits)
  {
    foreach (EnemyUnitSO enemyUnit in enemyUnits)
    {
      Debug.Log(enemyUnit.Name);
      GameObject obj = Instantiate(catalogButtonPrefab, transform);
      ButtonVE button = obj.GetComponent<ButtonVE>();
      button.TextChild.text = enemyUnit.Name;

      // Subscribe the necessary events
      EventTrigger.Entry hover = new EventTrigger.Entry() { eventID = EventTriggerType.PointerEnter };
      hover.callback.AddListener((data) => PreviewData(button));
      button.Trigger.triggers.Add(hover);

      EventTrigger.Entry select = new EventTrigger.Entry() { eventID = EventTriggerType.PointerClick};
      select.callback.AddListener((data) => SelectData(button));
      button.Trigger.triggers.Add(select);

      // EventTrigger.Entry deselect = new EventTrigger.Entry() { eventID = EventTriggerType.Deselect};
      // deselect.callback.AddListener((data) => SelectData(null));
      // button.Trigger.triggers.Add(deselect);

      EventTrigger.Entry exit = new EventTrigger.Entry() { eventID = EventTriggerType.PointerExit };
      exit.callback.AddListener((data) => EmptyData());
      button.Trigger.triggers.Add(exit);
      
      _catalogButtons.Add(button, enemyUnit);
    }
  }

  public void PreviewData(ButtonVE button)
  {
    _hoveredEnemyData = _catalogButtons[button];
    DisplayDetails(_hoveredEnemyData);
  }

  public void SelectData(ButtonVE button)
  {
    if(button)
    {
      _selectedEnemyData = _catalogButtons[button];
      DisplayDetails(_selectedEnemyData);
    }
  }

  public void EmptyData()
  {
    if (_selectedEnemyData)
      DisplayDetails(_selectedEnemyData);
    else
      _unitDetailsPanel.ClearDetails();

    _hoveredEnemyData = null;
  }

  public void DisplayDetails(UnitDataSO data)
  {
    _unitDetailsPanel.DisplayUnitDetails(data);
  }

  public void AddEnemy()
  {
    if(VacantEnemyButtons.TryPop(out UnitSim result))
    {
      ActiveEnemyButtons.Add(result);
      result.gameObject.SetActive(true);
      result.Data = _selectedEnemyData;
      result.UpdateDetails(_selectedEnemyData);
    }
  }

  public void DuplicateEnemy()
  {
    
  }

  public void RemoveEnemy(UnitSim unitButton)
  {
    if(ActiveEnemyButtons.Contains(unitButton))
    {
      UnitSim last = ActiveEnemyButtons.Last();

      // If this is somewhere in the middle of the stack
      if(ActiveEnemyButtons.Last() != unitButton)
      {
        int index = ActiveEnemyButtons.IndexOf(unitButton);
        int length = ActiveEnemyButtons.Count;

        for(int i = index; i < length - 1; i++)
        {
          UnitSim current = ActiveEnemyButtons[i];
          UnitSim next = ActiveEnemyButtons[i + 1];

          current.Data = next.Data;
          current.UpdateDetails(current.Data);

          next.Piece.tile.ReplacePiece(next.Piece, current.Piece);
        }
      }

      last.ClearDetails();
      last.gameObject.SetActive(false);
      
      ActiveEnemyButtons.Remove(last);
      VacantEnemyButtons.Push(last);
    }
  }
}
