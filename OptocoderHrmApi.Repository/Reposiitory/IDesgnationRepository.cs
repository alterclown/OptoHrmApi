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
    public interface IDesgnationRepository
    {
        Task<List<Position>> GetPositionList();
        Task<Position> GetPosition(int id);
        Task<Position> CreateNewPosition(Position position);
        Task<string> DeletePosition(int id);
        Task<string> UpdatePosition(int id, Position position);
    }

    public class DesinationRepository : IDesgnationRepository
    {
        private readonly DataContext _context;

        public DesinationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Position> CreateNewPosition(Position position)
        {
            try
            {
                _context.Positions.Add(position);
                await _context.SaveChangesAsync();
                return position;

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
                var res = await _context.Positions.FindAsync(id);
                _context.Positions.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";
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
                var res = await _context.Positions.FirstOrDefaultAsync(x => x.PositionId == id);
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
                var res = from c in _context.Positions
                          orderby c.PositionId descending
                          select c;
                return await res.ToListAsync();
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
                var response = await _context.Positions.FirstOrDefaultAsync(m => m.PositionId == id);
                response.EmployeeId = position.EmployeeId;
                response.PositionName = position.PositionName;
                response.UserId = position.UserId;
                response.CompanyId = position.CompanyId;
                _context.Positions.Update(response);
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
