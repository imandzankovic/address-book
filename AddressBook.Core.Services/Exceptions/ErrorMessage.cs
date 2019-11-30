

namespace AddressBook.Core.Services.Exceptions
{
    public class ErrorMessage
    {
        public string MessageCode { get; set; }  

        public ErrorMessage(string messageCode)
        {
            MessageCode = messageCode;
        }
    }
}
