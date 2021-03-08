using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface IDesignationService
    {
        Task<List<Position>> GetPositionList();
        Task<Position> GetPosition(int id);
        Task<Position> CreateNewPosition(Position position);
        Task<string> DeletePosition(int id);
        Task<string> UpdatePosition(int id, Position position);
    }
    public class DesignationService : IDesignationService
    {
        private readonly IiDesgnationRepository _reepository;

        public DesignationService(IiDesgnationRepository repository)
        {
            _reepository = repository;
        }
        public async Task<Position> CreateNewPosition(Position position)
        {
            try
            {
                var res = await _reepository.CreateNewPosition(position);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePosition(int id)
        {
            try
            {
                var res = await _reepository.DeletePosition(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Position> GetPosition(int id)
        {
            try
            {
                var res = await _reepository.GetPosition(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Position>> GetPositionList()
        {
            try
            {
                var res = await _reepository.GetPositionList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePosition(int id, Position position)
        {
            try
            {
                var res = await _reepository.UpdatePosition(id,position);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
