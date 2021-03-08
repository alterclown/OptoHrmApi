using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.Reposiitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.Services
{
    public interface ITrainingService
    {
        Task<List<training>> GetTrainingList();
        Task<training> GetTraining(int id);
        Task<training> CreateNewTraining(training training);
        Task<string> DeleteTraining(int id);
        Task<string> UpdateTraining(int id, training training);
    }
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _repository;

        public TrainingService(ITrainingRepository repository)
        {
            _repository = repository;
        }
        public async Task<training> CreateNewTraining(training training)
        {
            try
            {
                var res = await _repository.CreateNewTraining(training);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTraining(int id)
        {
            try
            {
                var res = await _repository.DeleteTraining(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<training> GetTraining(int id)
        {
            try
            {
                var res = await _repository.GetTraining(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<training>> GetTrainingList()
        {
            try
            {
                var res = await _repository.GetTrainingList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTraining(int id, training training)
        {
            try
            {
                var res = await _repository.UpdateTraining(id,training);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
