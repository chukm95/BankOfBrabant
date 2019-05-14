using System;

namespace BankOfBrabant.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Rhouder
    {
        public string rekeningHouder { get; set; }

    }
}