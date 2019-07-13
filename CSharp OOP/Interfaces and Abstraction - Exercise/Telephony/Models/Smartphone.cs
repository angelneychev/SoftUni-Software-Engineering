namespace Telephony.Models
{
    using System;
    using System.Linq;
    using Telephony.Contracts;
    using Telephony.Exceptions;
    public class Smartphone : IBrowseable, ICallable
    {
        public string Browse(string url)
        {
            if (url.Any(x=> char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }
            return $"Browsing: {url}!";
        }
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Calling... {phoneNumber}";
        }

    }
}
