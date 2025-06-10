using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Mapping;
using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Measure
{
    public class MeasureService : IMeasureService
    {
        private readonly MeasureRepository measureRepository;

        public MeasureService(MeasureRepository measureRepository)
        {
            this.measureRepository = measureRepository;
        }

        public async Task<MeasureServiceModel> CreateAsync(MeasureServiceModel model)
        {
            Data.Models.Measure measure = new Data.Models.Measure
            {
                BodyWeight = model.BodyWeight,
                MeasureDate = model.MeasureDate,
                UserId = model.UserId
            };

            Data.Models.Measure result = await measureRepository.CreateAsync(measure);

            return result.ToServiceModel();
        }

        public async Task<MeasureServiceModel> DeleteAsync(string id)
        {
            Data.Models.Measure measure = await measureRepository.GetAllAsNoTracking().FirstOrDefaultAsync(pb => pb.Id == id);

            if (measure == null)
            {
                throw new KeyNotFoundException("Measure not found.");
            }

            await measureRepository.DeleteAsync(measure);

            return measure.ToServiceModel();
        }

        public IQueryable<MeasureServiceModel> GetAll()
        {
            return measureRepository.GetAll()
                .Select(m => m.ToServiceModel());
        }

        public IQueryable<MeasureServiceModel> GetAllByUserId(string userId)
        {
            return measureRepository.GetAll()
                .Where(m => m.UserId == userId)
                .Select(m => m.ToServiceModel());
        }

        public async Task<MeasureServiceModel> GetByIdAsync(string id)
        {
            Data.Models.Measure measure = await measureRepository
                .GetAllAsNoTracking()
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            
            if (measure == null)
            {
                return null;
            }

            return measure.ToServiceModel();
        }

        public async Task<MeasureServiceModel> UpdateAsync(string id, MeasureServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
