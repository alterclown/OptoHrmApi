﻿using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IPayGradeRepository
    {
        Task<ICollection<PayGrade>> GetPayGradeList();
        Task<PayGrade> GetPayGrade(int id);
        Task<PayGrade> CreateNewPayGrade(PayGrade payGrade);

        Task<string> DeletePayGrade(int id);
        Task<string> UpdatePayGrade(int id, PayGrade payGrade);
    }

    public class PayGradeRepository : IPayGradeRepository
    {
        private readonly DataContext _context;

        public PayGradeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PayGrade> CreateNewPayGrade(PayGrade payGrade)
        {
            try
            {
                _context.PayGrades.Add(payGrade);
                await _context.SaveChangesAsync();
                return payGrade;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePayGrade(int id)
        {
            try
            {
                var response = await _context.PayGrades.FindAsync(id);
                _context.PayGrades.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PayGrade> GetPayGrade(int id)
        {
            try
            {
                var res = await _context.PayGrades.FirstOrDefaultAsync(m => m.PayGradeId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PayGrade>> GetPayGradeList()
        {
            try
            {
                var response = from c in _context.PayGrades
                               orderby c.PayGradeId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePayGrade(int id, PayGrade payGrade)
        {
            try
            {
                var res = await _context.PayGrades.FirstOrDefaultAsync(m => m.PayGradeId == id);
                res.PayGradeName = payGrade.PayGradeName;
                res.MinSalary = payGrade.MinSalary;
                res.MaxSalary = payGrade.MaxSalary;
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
