using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Table<Key, Value>
{
    static Dictionary<Key, Value> m_mapTb = new Dictionary<Key, Value>();
    
    public static void Clear()
    {
        m_mapTb.Clear();
    }

    public static void SetTable(Key a_key, Value a_val)
    {
        try
        {
            m_mapTb.Add(a_key, a_val);
        }
        catch
        {
            Debug.LogError("테이블을 체크하세요.");
        }
    }

    public static void AdjustTable(Key a_key, Value a_val)
    {
        try
        {
            m_mapTb[a_key] = a_val;
        }
        catch
        {
            Debug.LogError("수정이 완료되지 않았습니다.");
        }
    }

    public static Value GetTable(Key a_key)
    {
        Value val;
        m_mapTb.TryGetValue(a_key, out val);
        return val;
    }

    public static int Count()
    {
        return m_mapTb.Count;
    }
}