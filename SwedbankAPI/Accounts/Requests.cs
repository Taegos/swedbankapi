using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankAPI.Accounts.Requests
{
    public class ConsentAccountBody
    {
        public string iban = "string";
    }

    public class ConsentAccessBody
    {
        public List<ConsentAccountBody> accounts = new List<ConsentAccountBody> { new ConsentAccountBody() };
        public List<ConsentAccountBody> balances = new List<ConsentAccountBody> { new ConsentAccountBody() };
        public List<ConsentAccountBody> transactions = new List<ConsentAccountBody> { new ConsentAccountBody() };
        public string availableAccounts = "allAccounts";
    }

    public class CreateConsentRequest
    {
        public ConsentAccessBody access = new ConsentAccessBody();
        public bool combinedServiceIndicator = true;
        public int frequencyPerDay = 0;
        public bool recurringIndicator = false;
        public string validUntil = "2020-05-25";
    }
}