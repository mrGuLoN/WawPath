using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPooledObjects
{
    PollObjects.ObjectInfo.ObjectType Type { get; }
}