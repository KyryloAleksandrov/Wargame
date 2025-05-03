using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HexPosition : IEquatable<HexPosition>
{
    public int x;  //column
    public int z; //row

    public HexPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString() => $"{x}; {z}";

    public static bool operator == (HexPosition a, HexPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator != (HexPosition a, HexPosition b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is HexPosition position &&
            x == position.x &&
            z == position.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public bool Equals(HexPosition other)
    {
        return this == other;
    }

    public static HexPosition operator +(HexPosition a, HexPosition b)
    {
        return new HexPosition(a.x + b.x, a.z + b.z);
    }

    public static HexPosition operator -(HexPosition a, HexPosition b)
    {
        return new HexPosition(a.x - b.x, a.z - b.z);
    }
}
