using System;
using System.Collections.Generic;

namespace CarPark.DatabaseContext;

public partial class CarParkInfoDetail
{
    public int CpId { get; set; }

    public string? NameC { get; set; }

    public string? LocationC { get; set; }

    public string? CarParkEntryC { get; set; }

    public string? ContactNo { get; set; }

    public string? NameP { get; set; }

    public string? LocationP { get; set; }

    public string? CarParkEntryP { get; set; }

    public double? XCoords { get; set; }

    public double? YCoords { get; set; }

    public string? Height { get; set; }

    public string? DsccX { get; set; }

    public string? DsccY { get; set; }

    public string? LcarPriceC { get; set; }

    public string? HcarPriceC { get; set; }

    public string? MotoPriceC { get; set; }

    public string? RemarkPriceC { get; set; }

    public string? LcarPriceP { get; set; }

    public string? HcarPriceP { get; set; }

    public string? MotoPriceP { get; set; }

    public string? RemarkPriceP { get; set; }

    public string? ZoneC { get; set; }

    public string? ZoneP { get; set; }

    public string? ZoneE { get; set; }

    public string? SubdistrictC { get; set; }

    public string? SubdistrictP { get; set; }

    public string? SubdistrictE { get; set; }

    public string? NameE { get; set; }

    public string? LocationE { get; set; }

    public string? CarParkEntryE { get; set; }

    public string? LcarPriceE { get; set; }

    public string? HcarPriceE { get; set; }

    public string? MotoPriceE { get; set; }

    public string? RemarkPriceE { get; set; }
}
