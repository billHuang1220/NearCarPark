using System;
using System.Collections.Generic;

namespace CarPark.DatabaseContext;

public partial class CarParkInfoRealTime
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string CpEname { get; set; }

    public string CpPname { get; set; }

    public int CarCnt { get; set; }

    public int MbCnt { get; set; }

    public DateTime Time { get; set; }

    public bool Maintenance { get; set; }
}
