using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeeEmergencyContactRepository
    {
        Task<ICollection<EmployeeEmergencyContact>> GetEmployeeEmergencyContactList();
        Task<EmployeeEmergencyContact> GetEmployeeEmergencyContact(int id);
        Task<EmployeeEmergencyContact> CreateNewEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact);

        Task<string> DeleteEmployeeEmergencyContact(int id);
        Task<string> UpdateEmployeeEmergencyContact(int id, EmployeeEmergencyContact employeeEmergencyContact);
    }
    public class EmployeeEmergencyContactRepository : IEmployeeEmergencyContactRepository
    {
        private readonly DataContext _context;

        public EmployeeEmergencyContactRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EmployeeEmergencyContact> CreateNewEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact)
        {
            try
            {
                _context.EmployeeEmergencyContacts.Add(employeeEmergencyContact);
                await _context.SaveChangesAsync();
                return employeeEmergencyContact;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeEmergencyContact(int id)
        {
            try
            {
                var response = await _context.EmployeeEmergencyContacts.FindAsync(id);
                _context.EmployeeEmergencyContacts.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeEmergencyContact> GetEmployeeEmergencyContact(int id)
        {
            try
            {
                var res = await _context.EmployeeEmergencyContacts.FirstOrDefaultAsync(m => m.EmployeeContactId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<EmployeeEmergencyContact>> GetEmployeeEmergencyContactList()
        {
            try
            {
                var response = from c in _context.EmployeeEmergencyContacts
                               orderby c.EmployeeContactId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateEmployeeEmergencyContact(int id, EmployeeEmergencyContact employeeEmergencyContact)
        {
            try
            {
                var res = await _context.EmployeeEmergencyContacts.FirstOrDefaultAsync(m => m.EmployeeContactId == id);
                res.EmployeeName = employeeEmergencyContact.EmployeeName;
                res.Name = employeeEmergencyContact.Name;
                res.Relationship = employeeEmergencyContact.Relationship;
                res.HomePhone = employeeEmergencyContact.HomePhone;
                res.WorkPhone = employeeEmergencyContact.WorkPhone;
                res.MobilePhone = employeeEmergencyContact.MobilePhone;
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
