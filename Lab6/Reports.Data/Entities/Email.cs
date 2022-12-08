using System;

namespace Reports.Data.Entities
{
    [Serializable]
    public class Email
    {
        public Email(string email)
        {
            EmailText = email;
        }

        public string EmailText { get; }
    }
}
