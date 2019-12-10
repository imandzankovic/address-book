using AddressBook.Entities;
using AddressBook.Repository;
using System.Threading.Tasks;
using Xunit;

namespace AddressBook.Tests
{
    public class RepositoryTests : BaseUnitTest
    {
        private readonly ContactRepository _contactRepository;
        public RepositoryTests()
        {
            _contactRepository = GetInMemoryPersonRepository();
        }
        public Contact getTestContact()
        {

            Contact contact = new Contact()
            {
                Id = 1,
                FirstName = "Isabel",
                LastName = "Moore",
                Phone = 0986532145,
                Email = "isabel@hotmail.com"
            };

            return contact;
        }

        [Fact]
        public async Task Add_ContactAsync()
        {

            Contact savedContact = await _contactRepository.Add(getTestContact());
            var contacts = _contactRepository.GetAll().Result.Count;

            Assert.Equal(1, contacts);
            Assert.Equal("Isabel", savedContact.FirstName);
            Assert.Equal("Moore", savedContact.LastName);

        }

        [Fact]
        public async Task GetById_ContactAsync()
        {

            Contact savedContact = await _contactRepository.Add(getTestContact());
            var fetchedContact = _contactRepository.Get(1).Result;

            Assert.Equal(savedContact.FirstName, fetchedContact.FirstName);
            Assert.Equal(savedContact.LastName, fetchedContact.LastName);

        }

        [Fact]
        public async Task Update_ContactAsync()
        {

            Contact savedContact = await _contactRepository.Add(getTestContact());
            var fetchedContact = _contactRepository.Get(1).Result;

            Assert.Equal(savedContact.FirstName, fetchedContact.FirstName);
            Assert.Equal(savedContact.LastName, fetchedContact.LastName);

        }

        [Fact]
        public async Task Delete_ContactAsync()
        {

            Contact savedContact = await _contactRepository.Add(getTestContact());
            var deletedContact =  _contactRepository.Delete(savedContact.Id).Result;

            var fetchedContacts = _contactRepository.GetAll().Result.Count;

            Assert.Equal(1, deletedContact.Id);
            Assert.Equal(0, fetchedContacts);

        }

    }
}
