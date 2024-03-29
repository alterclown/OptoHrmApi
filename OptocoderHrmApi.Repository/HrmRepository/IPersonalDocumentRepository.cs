﻿using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IPersonalDocumentRepository
    {
        Task<ICollection<PersonalDocument>> GetPersonalDocumentList();
        Task<PersonalDocument> GetPersonalDocument(int id);
        Task<PersonalDocument> CreateNewPersonalDocument(PersonalDocument personalDocument);

        Task<string> DeletePersonalDocument(int id);
        Task<string> UpdatePersonalDocument(int id, PersonalDocument personalDocument);
    }

    public class PersonalDocumentRepository : IPersonalDocumentRepository
    {
        private readonly DataContext _context;

        public PersonalDocumentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PersonalDocument> CreateNewPersonalDocument(PersonalDocument personalDocument)
        {
            try
            {
                _context.PersonalDocuments.Add(personalDocument);
                await _context.SaveChangesAsync();
                return personalDocument;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePersonalDocument(int id)
        {
            try
            {
                var response = await _context.PersonalDocuments.FindAsync(id);
                _context.PersonalDocuments.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PersonalDocument> GetPersonalDocument(int id)
        {
            try
            {
                var res = await _context.PersonalDocuments.FirstOrDefaultAsync(m => m.PersonalDocumentId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<PersonalDocument>> GetPersonalDocumentList()
        {
            try
            {
                var response = from c in _context.PersonalDocuments
                               orderby c.PersonalDocumentId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePersonalDocument(int id, PersonalDocument personalDocument)
        {
            try
            {
                var res = await _context.PersonalDocuments.FirstOrDefaultAsync(m => m.PersonalDocumentId == id);
                res.Document = personalDocument.Document;
                res.ValidUntil = personalDocument.ValidUntil;
                res.Status = personalDocument.Status;
                res.Details = personalDocument.Details;
                res.Attachment = personalDocument.Attachment;
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
