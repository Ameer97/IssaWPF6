using IssaWPF6.DAL;
using IssaWPF6.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssaWPF6.Service
{
    public interface IDataService
    {
        public Task<Colon> AddColon(Colon item);
        public Task ExportColons();
        public Task ExportStomaches();
        public Task<Stomach> AddStomach(Stomach item);
    }
    public class DataService : IDataService
    {
        public async Task<Colon> AddColon(Colon item)
        {
            using(var db = new ApplicationDbContext())
            {
                await db.Colons.AddAsync(item);
                await db.SaveChangesAsync();
                return item;
            } 
        }
        
        public async Task<Stomach> AddStomach(Stomach item)
        {
            using(var db = new ApplicationDbContext())
            {
                await db.Stomaches.AddAsync(item);
                await db.SaveChangesAsync();
                return item;
            } 
        }

        public async Task ExportColons()
        {
            using(var db = new ApplicationDbContext())
            {
                var colons = await db.Colons.Select(c => new ColonDto(c)).ToListAsync();
                await Common.SaveExcel(colons);
            }
        }

        public async Task ExportStomaches()
        {
            using (var db = new ApplicationDbContext())
            {
                var colons = await db.Stomaches.Select(c => new StomachDto(c)).ToListAsync();
                await Common.SaveExcel(colons);
            }
        }


    }
}
