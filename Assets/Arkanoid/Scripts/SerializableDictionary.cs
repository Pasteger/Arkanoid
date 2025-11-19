using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [field: SerializeField]
    public List<SerializableKeyValuePair<TKey, TValue>> SerializableKeyValuePairList { get; private set; }

    public void Add(TKey key, TValue value) =>
        SerializableKeyValuePairList.Add(new SerializableKeyValuePair<TKey, TValue>(key, value));

    public TValue GetValue(TKey key) => SerializableKeyValuePairList.FirstOrDefault(pair => pair.Key.Equals(key)).Value;
}