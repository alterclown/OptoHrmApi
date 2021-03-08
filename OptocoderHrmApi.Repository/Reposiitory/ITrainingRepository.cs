using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface ITrainingRepository
    {
        Task<List<training>> GetTrainingList();
        Task<training> GetTraining(int id);
        Task<training> CreateNewTraining(training training);
        Task<string> DeleteTraining(int id);
        Task<string> UpdateTraining(int id, training training);
    }
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DataContext _context;

        public TrainingRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<training> CreateNewTraining(training train)
        {
            try
            {
                _context.training.Add(train);
                await _context.SaveChangesAsync();
                return train;
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
                var res = await _context.training.FindAsync(id);
                _context.training.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";

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
                var res = await _context.training.FirstOrDefaultAsync(x => x.TrainingId == id);
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
                var res = from c in _context.training
                          orderby c.TrainingId descending
                          select c;
                return await res.ToListAsync();

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
                var response = await _context.training.FirstOrDefaultAsync(m => m.TrainingId == id);
                response.EmployeeId = training.EmployeeId;
                response.TrainingProvider = training.TrainingProvider;
                response.Trainee = training.Trainee;
                response.ProjectName = training.ProjectName;
                response.TrainingLocation = training.TrainingLocation;
                response.StartDate = training.StartDate;
                response.EndDate = training.EndDate;
                response.Status = training.Status;
                response.CompanyId = training.CompanyId;
                response.UserId = training.UserId;
                _context.training.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
