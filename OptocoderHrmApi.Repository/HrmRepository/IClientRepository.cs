using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IClientRepository
    {
        Task<ICollection<Client>> GetClientList();
        Task<Client> GetClient(int id);
        Task<Client> CreateNewClient(Client client);

        Task<string> DeleteClient(int id);
        Task<string> UpdateClient(int id, Client client);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Client> CreateNewClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return client;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteClient(int id)
        {
            try
            {
                var response = await _context.Clients.FindAsync(id);
                _context.Clients.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Client> GetClient(int id)
        {
            try
            {
                var res = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Client>> GetClientList()
        {
            try
            {
                var response = from c in _context.Clients
                               orderby c.ClientId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateClient(int id, Client client)
        {
            try
            {
                var res = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);
                res.ClientName = client.ClientName;
                res.Details = client.Details;
                res.Address = client.Address;
                res.ContactNumber = client.ContactNumber;
                res.ContactEmail = client.ContactEmail;
                res.CompanyUrl = client.CompanyUrl;
                res.Status = client.Status;
                res.FirstContactDate = client.FirstContactDate;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
