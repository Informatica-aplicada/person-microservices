using System.Data.SqlTypes;
namespace apiPersonaNet.Models
{
    public class PersonInfo
    {

        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public int NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        public string rowguid { get; set; }
        public SqlDateTime? ModifiedDate { get; set; }
    }
}