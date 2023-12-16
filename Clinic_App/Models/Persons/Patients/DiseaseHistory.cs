public class DiseaseHistory
{
    public int? Id { get; set; }
    public required string Disease { get; set; }
    public bool? IsReanimation { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    //public DiseaseHistory( string Disease,
    //    int[] StartDate,
    //    int[]? EndDate = null,
    //    bool? IsReanimation = null)
    //{
    //    this.Disease = Disease;
    //    this.IsReanimation = IsReanimation;
    //    this.StartDate = new DateTime(StartDate[0], StartDate[1], StartDate[2]);
    //    this.EndDate = EndDate != null 
    //        ? new DateTime(EndDate[0], EndDate[1], EndDate[2])
    //        : null;
    //}
};