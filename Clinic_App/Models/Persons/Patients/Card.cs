public class Card {
    public int? Id { get; set; }
    public required List<DiseaseHistory> Diseases { get; set; }
    //public Card(DiseaseHistory Disease) {
    //    this?.Diseases?.Add(Disease);
    //}
};