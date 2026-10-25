namespace ScottishGlenApp.Models
{
    public class Asset{
        public int assetID{get; set;}
        public string systemName {get; set;} = string.Empty;
        public string model {get; set;} = string.Empty;
        public string manufacturer {get; set;} = string.Empty;
        public string type {get; set;} = string.Empty;
        public string ipAddress {get; set;} = string.Empty;
        public DateTime? purchaseDate {get; set;} = null;
        public string notes {get; set;} = string.Empty;
        public int employeeID {get; set;} = 0;
    }

}