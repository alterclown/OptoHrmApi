using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OptocoderHrmApi.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface ITrainingSetupRepository
    {
        Task<ICollection<TrainingSetup>> GetTrainingSetupList();
        Task<TrainingSetup> GetTrainingSetup(int id);
        Task<TrainingSetup> CreateNewTrainingSetup(TrainingSetup trainingSetup);

        Task<string> DeleteTrainingSetup(int id);
        Task<string> UpdateTrainingSetup(int id, TrainingSetup trainingSetup);
    }

    public class TrainingSetupRepository : ITrainingSetupRepository
    {
        private readonly DataContext _context;

        public TrainingSetupRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<TrainingSetup> CreateNewTrainingSetup(TrainingSetup trainingSetup)
        {
            try
            {
                _context.TrainingSetups.Add(trainingSetup);
                await _context.SaveChangesAsync();
                return trainingSetup;
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
                var response = await _context.TrainingSetups.FindAsync(id);
                _context.TrainingSetups.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.TrainingSetups.FirstOrDefaultAsync(m => m.TrainingSetupId == id);
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
                var response = from c in _context.TrainingSetups
                               orderby c.TrainingSetupId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.TrainingSetups.FirstOrDefaultAsync(m => m.TrainingSetupId == id);
                res.Code = trainingSetup.Code;
                res.TrainingName = trainingSetup.TrainingName;
                res.Coordinator = trainingSetup.Coordinator;
                res.Trainer = trainingSetup.Trainer;
                res.TraineeName = trainingSetup.TraineeName;
                res.TrainingDetails = trainingSetup.TrainingDetails;
                res.PaymentType = trainingSetup.PaymentType;
                res.Currency = trainingSetup.Currency;
                res.Cost = trainingSetup.Cost;
                res.StartDate = trainingSetup.StartDate;
                res.EndDate = trainingSetup.EndDate;
                res.Status = trainingSetup.Status;
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
