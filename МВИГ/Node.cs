using System;

struct Info : IComparable<Info>
{
    static public int MaxMass;

    public int Mass;
    public int Cost;
    public int N;
  
    public double E;

    public int CompareTo(Info info)
    {
        if (this.E < info.E)
            return 1;
        else
        if (this.E == info.E)
            return 0;
        else
            return -1;
    }
    public override string ToString()
    {
        return "№" + N.ToString() + " Mасса = " + Mass.ToString() + " Cтоимость = " + Cost.ToString();
    }
}