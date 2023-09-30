﻿using IssaWPF6.DAL;
using IssaWPF6.Dtos;
using IssaWPF6.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace IssaWPF6.Service
{
    public interface IDataService
    {
        public Task<Colon> AddColon(Colon item);
        public Task ExportColons();
        public Task ExportStomaches();
        public Task<Stomach> AddStomach(Stomach item);
        public Task<List<StomachDto>> Stomaches();
        public Task<List<ColonDto>> Colons();
        public Stomach EditStomache(int? id = null);
        public Colon EditColon(int? id = null);
        public void Migrate();
        public Photo SetImage(string photoPath, string Name, int typeId, int objectId);
        public Task<List<KeyValuDto>> GetImage(int typeId, int objectId);
        public void DeleteColon(int id);
        public void DeleteStomach(int id);


    }
    public class DataService : IDataService
    {
        public async Task<Colon> AddColon(Colon item)
        {
            using(var db = new ApplicationDbContext())
            {
                if(!(item.Id > 0))
                    await db.Colons.AddAsync(item);
                else
                    db.Colons.Update(item);
                await db.SaveChangesAsync();
                return item;
            } 
        }
        public void DeleteColon(int id)
        {
            using(var db = new ApplicationDbContext())
            {
                var item = db.Colons.FirstOrDefault(x => x.Id == id);
                if(item == null)
                    return;
                db.Colons.Remove(item);
                db.SaveChanges();
            } 
        }
        public void DeleteStomach(int id)
        {
            using(var db = new ApplicationDbContext())
            {
                var item = db.Stomaches.FirstOrDefault(x => x.Id == id);
                if (item == null)
                    return;
                db.Stomaches.Remove(item);
                db.SaveChanges();
            } 
        }
        
        public async Task<Stomach> AddStomach(Stomach item)
        {
            using(var db = new ApplicationDbContext())
            {
                if (!(item.Id > 0))
                    await db.Stomaches.AddAsync(item);
                else
                    db.Stomaches.Update(item);
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

        public async Task<List<StomachDto>> Stomaches()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Stomaches
                    .Select(c => new StomachDto(c)).ToListAsync();
            }
        }
        

        public async Task<List<ColonDto>> Colons()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Colons
                    .Select(c => new ColonDto(c)).ToListAsync();
            }
        }


        public Stomach EditStomache(int? id = null)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Stomaches
                    .First(x => id == null || x.Id == id);
            }
        }


        public Colon EditColon(int? id = null)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Colons
                    .First(x => id == null || x.Id == id);
            }
        }

        public void Migrate()
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.Migrate();

            }
        }



        public Photo SetImage(string photoPath, string Name, int typeId, int objectId)
        {
            var photo = new Photo { Data = File.ReadAllBytes(photoPath), Name = Name, TypeId = typeId, ObjectId = objectId };

            using (var db = new ApplicationDbContext())
            {
                db.Photos.Add(photo);
                db.SaveChanges();
                return photo;
            }
        }

        public async Task<List<KeyValuDto>> GetImage(int typeId, int objectId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Photos.Where(p => p.TypeId == typeId && p.ObjectId == objectId)
                    .Select(x => new KeyValuDto { Key=x.Name,Value = x.Data.TempPath() })
                    .ToListAsync();
            }
        }
    }
}
