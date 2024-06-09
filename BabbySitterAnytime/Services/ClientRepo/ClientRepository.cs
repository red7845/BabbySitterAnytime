using BabbySitterAnytime.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.Services.ClientRepo
{

    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContenxt;

        public ClientRepository(AppDbContext appDbContenxt)
        {
            _appDbContenxt = appDbContenxt;
        }
        public async Task CreateProfile(Customer customer)
        {
            _appDbContenxt.Customers.Add(customer);
            await _appDbContenxt.SaveChangesAsync();
        }

        public async Task EditProfile(Customer customer)
        {
            try
            {
                _appDbContenxt.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _appDbContenxt.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Customer> GetCustomerByUserId(string userId)
        {
            return await _appDbContenxt.Customers.Where(c => c.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<Customer> ProfileDetails(Guid id)
        {
            return await _appDbContenxt.Customers.FindAsync(id);
        }
    }
}
