using S8__Complet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S8__Complet.Repository
{
    public class PredictionRepository
    {
        private readonly Models.Entities _context = null;
        public PredictionRepository(Entities entities)
        {
            this._context = entities;
        }
        public IEnumerable<Prediction> GetPrediction()
        {
            return _context.Prediction.ToList();
        }
        public Prediction GetPredictionID(int id)
        {
            return _context.Prediction.Find(id);
        }
        public void InsertPrediction(Prediction pred)
        {
            _context.Prediction.Add(pred);
        }
        public void DeletePrediction(int predID)
        {
            Prediction pred = _context.Prediction.Find(predID);
            _context.Prediction.Remove(pred);
        }
        public void UpdatePrediction(Prediction pred)
        {
            _context.Entry(pred).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}