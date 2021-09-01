using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(validOn: System.AttributeTargets.Field | System.AttributeTargets.Property | System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
public class DisableFieldAttribute : PropertyAttribute
{

}