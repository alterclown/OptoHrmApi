using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface IClientService
    {
        Task<ICollection<Client>> GetClientList();
        Task<Client> GetClient(int id);
        Task<Client> CreateNewClient(Client Client);

        Task<string> DeleteClient(int id);
        Task<string> UpdateClient(int id, Client Client);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public async Task<Client> CreateNewClient(Client client)
        {
            try
            {
                var res = await _repository.CreateNewClient(client);
                return res;
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
                var res = await _repository.DeleteClient(id);
                return res;
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
                var res = await _repository.GetClient(id);
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
                var res = await _repository.GetClientList();
                return res;
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
                var res = await _repository.UpdateClient(id, client);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
