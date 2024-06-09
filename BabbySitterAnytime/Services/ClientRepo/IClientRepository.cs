using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.ClientRepo
{
    public interface IClientRepository
    {
        Task CreateProfile(Customer client);
        Task EditProfile(Customer customer);
        Task<Customer> ProfileDetails(Guid id);
        Task<Customer> GetCustomerByUserId(string userId);
    }
}
