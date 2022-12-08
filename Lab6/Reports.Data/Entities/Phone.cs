namespace Reports.Data.Entities
{
    public class Phone
    {
        public Phone(string phone)
        {
            PhoneNumber = phone;
        }

        public string PhoneNumber { get; }
    }
}
