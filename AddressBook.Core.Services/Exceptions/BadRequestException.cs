
namespace AddressBook.Core.Services.Exceptions
{
    public class BadRequestException : ServiceException
    {
        private readonly string messageCode;

        public override int StatusCode => 400;

        public override object Value => new ErrorMessage(messageCode);

        public BadRequestException(string messageCode)
        {
            this.messageCode = messageCode;
        }
    }
}
