
using System.Collections.Generic;
using UnityEngine;

namespace Consystent
{
  namespace Systems
  {
    public class System : MonoBehaviour
    {
      [Header("System")]
      /// <summary>
      /// The [System] shall know about its subsystems.
      /// </summary>
      public HashSet<Subsystem> Subsystems;
    }

    public class Subsystem : MonoBehaviour
    {
      [Header("Subsystem")]

      /// <summary>
      /// The [Subsystem] shall know what system it belongs to.
      /// </summary>
      public System System;

      /// <summary>
      /// The [Subsystem] shall know about its assemblies.
      /// </summary>
      public HashSet<Assembly> Assemblies;
    }

    public class Assembly : MonoBehaviour
    {
      [Header("Assembly")]

      /// <summary>
      /// The [Assembly] shall know what subsystem it belongs to.
      /// </summary> 
      public readonly Subsystem Subsystem;

      /// <summary>
      /// The [Assembly] shall know about its components.
      /// </summary>
      public HashSet<Component> Components;
    }

    public class Component : MonoBehaviour
    {
      [Header("Component")]
      /// <summary>
      /// The [Component] shall know what assembly it belongs to.
      /// </summary>
      public Assembly Assembly;
    }
  }
}
