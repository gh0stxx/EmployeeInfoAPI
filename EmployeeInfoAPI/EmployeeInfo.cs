namespace EmployeeInfoAPI
{
    public class EmployeeInfo
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty ;
        public string State { get; set; } = string.Empty ;
        public int Dept { get; set; }
        public string Street { get; set; } = string.Empty;  
        public string City { get; set; } = string.Empty;    
        public string PostCode { get; set; } = string.Empty;    
        public string Country { get; set; } = string.Empty;

    }
}
