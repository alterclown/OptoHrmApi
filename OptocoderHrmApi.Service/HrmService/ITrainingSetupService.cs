using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ITrainingSetupService
    {
        Task<ICollection<TrainingSetup>> GetTrainingSetupList();
        Task<TrainingSetup> GetTrainingSetup(int id);
        Task<TrainingSetup> CreateNewTrainingSetup(TrainingSetup trainingSetup);

        Task<string> DeleteTrainingSetup(int id);
        Task<string> UpdateTrainingSetup(int id, TrainingSetup trainingSetup);
    }

    public class TrainingSetupService : ITrainingSetupService
    {
        private readonly ITrainingSetupRepository _repository;

        public TrainingSetupService(ITrainingSetupRepository repository)
        {
            _repository = repository;
        }
        public async Task<TrainingSetup> CreateNewTrainingSetup(TrainingSetup trainingSetup)
        {
            try
            {
                var res = await _repository.CreateNewTrainingSetup(trainingSetup);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTrainingSetup(int id)
        {
            try
            {
                var res = await _repository.DeleteTrainingSetup(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TrainingSetup> GetTrainingSetup(int id)
        {
            try
            {
                var res = await _repository.GetTrainingSetup(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TrainingSetup>> GetTrainingSetupList()
        {
            try
            {
                var res = await _repository.GetTrainingSetupList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTrainingSetup(int id, TrainingSetup trainingSetup)
        {
            try
            {
                var res = await _repository.UpdateTrainingSetup(id, trainingSetup);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
