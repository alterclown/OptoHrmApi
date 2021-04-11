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
    public interface ITrainingSessionRepository
    {
        Task<ICollection<TrainingSession>> GetTrainingSessionList();
        Task<TrainingSession> GetTrainingSession(int id);
        Task<TrainingSession> CreateNewTrainingSession(TrainingSession trainingSession);

        Task<string> DeleteTrainingSession(int id);
        Task<string> UpdateTrainingSession(int id, TrainingSession trainingSession);
    }

    public class TrainingSessionRepository : ITrainingSessionRepository
    {
        private readonly DataContext _context;

        public TrainingSessionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<TrainingSession> CreateNewTrainingSession(TrainingSession trainingSession)
        {
            try
            {
                _context.TrainingSessions.Add(trainingSession);
                await _context.SaveChangesAsync();
                return trainingSession;
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
                var response = await _context.TrainingSessions.FindAsync(id);
                _context.TrainingSessions.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.TrainingSessions.FirstOrDefaultAsync(m => m.TrainingSessionId == id);
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
                var response = from c in _context.TrainingSessions
                               orderby c.TrainingSessionId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.TrainingSessions.FirstOrDefaultAsync(m => m.TrainingSessionId == id);
                res.Course = trainingSession.Course;
                res.TrainingName = trainingSession.TrainingName;
                res.Details = trainingSession.Details;
                res.ScheduledTime = trainingSession.ScheduledTime;
                res.AssignmentDueDate = trainingSession.AssignmentDueDate;
                res.DeliveryMethod = trainingSession.DeliveryMethod;
                res.DeliveryLocation = trainingSession.DeliveryLocation;
                res.AttendanceType = trainingSession.AttendanceType;
                res.AttendanceStatus = trainingSession.AttendanceStatus;
                res.AttendanceFeedback = trainingSession.AttendanceFeedback;
                res.ProofOfCompletion = trainingSession.ProofOfCompletion;
                res.Attachment = trainingSession.Attachment;
                res.TrainingCertificate = trainingSession.TrainingCertificate;
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
