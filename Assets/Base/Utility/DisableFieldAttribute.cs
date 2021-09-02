using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
public class DisableFieldAttribute : PropertyAttribute
{

}