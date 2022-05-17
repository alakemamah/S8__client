using S8__Complet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S8__Complet.Repository
{
    public class DonneeRepository
    {
        private readonly Entities _context;
        public DonneeRepository(Entities entities)
        {
            this._context = entities;
        }
        public IEnumerable<Donnees> GetDonnee()
        {
            return _context.Donnees.ToList();
        }
        public List<String> GetDonneeName()
        {
            List<string> dataNames = new List<string>();
            foreach(Donnees donnee in _context.Donnees)
            {
                dataNames.Add(donnee.DataName);
            }

            return dataNames;
        }

        public Donnees GetDonneeByID(int id)
        {
            return _context.Donnees.Find(id);
        }
        public void InsertDonnee(Donnees donnee)
        {
            _context.Donnees.Add(donnee);
        }
        public void DeleteDonnee(int donneeID)
        {
            Donnees donnee = _context.Donnees.Find(donneeID);
            _context.Donnees.Remove(donnee);
        }
        public void UpdateDonnee(Donnees donnee)
        {
            _context.Entry(donnee).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}