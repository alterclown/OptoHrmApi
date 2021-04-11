using OptocoderHrmApi.Data.Entities;
using OptocoderHrmApi.Repository.HrmRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptocoderHrmApi.Service.HrmService
{
    public interface ITrainingSessionService
    {
        Task<ICollection<TrainingSession>> GetTrainingSessionList();
        Task<TrainingSession> GetTrainingSession(int id);
        Task<TrainingSession> CreateNewTrainingSession(TrainingSession trainingSession);

        Task<string> DeleteTrainingSession(int id);
        Task<string> UpdateTrainingSession(int id, TrainingSession trainingSession);
    }

    public class TrainingSessionService : ITrainingSessionService
    {
        private readonly ITrainingSessionRepository _repository;

        public TrainingSessionService(ITrainingSessionRepository repository)
        {
            _repository = repository;
        }
        public async Task<TrainingSession> CreateNewTrainingSession(TrainingSession trainingSession)
        {
            try
            {
                var res = await _repository.CreateNewTrainingSession(trainingSession);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTrainingSession(int id)
        {
            try
            {
                var res = await _repository.DeleteTrainingSession(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TrainingSession> GetTrainingSession(int id)
        {
            try
            {
                var res = await _repository.GetTrainingSession(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TrainingSession>> GetTrainingSessionList()
        {
            try
            {
                var res = await _repository.GetTrainingSessionList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTrainingSession(int id, TrainingSession trainingSession)
        {
            try
            {
                var res = await _repository.UpdateTrainingSession(id, trainingSession);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
