using UnityEngine;

public struct DamageElements
{
  [SerializeField] private bool blunt;
  public bool Blunt => blunt;
  [SerializeField] private bool slash;
  public bool Slash => slash;
  [SerializeField] private bool pierce;
  public bool Pierce => pierce;
  [SerializeField] private bool blast;
  public bool Blast => blast;
  [SerializeField] private bool water;
  public bool Water => water;
  [SerializeField] private bool earth;
  public bool Earth => earth;
  [SerializeField] private bool wind;
  public bool Wind => wind;
  [SerializeField] private bool fire;
  public bool Fire => fire;
}
