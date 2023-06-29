
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_LearnDemo.Data;
using web_api_LearnDemo.Models.Domain;
using web_api_LearnDemo.Models.DTO;

namespace web_api_LearnDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly StudentWebApiDbContext dbContext;
        public ContactController(StudentWebApiDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        #region Get All Student
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
          return Ok(await dbContext.Contacts.ToListAsync());
        }

        #endregion

        #region Get ContactByPK

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContactByPK([FromRoute] int id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        #endregion

        #region Add Contact
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Name = addContactRequest.Name,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address

            };
            await dbContext.Contacts.AddAsync(contact); 
            await dbContext.SaveChangesAsync(); 
            return Ok(contact);
        }

        #endregion

        #region Update Contact

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.Name = updateContactRequest.Name;   
                contact.Email = updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;

                await dbContext.SaveChangesAsync();
                return Ok(contact);

            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Delete Contact

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
           var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);

            }
            else
            {

                return NotFound();
            }
        }
        #endregion
    }
}
