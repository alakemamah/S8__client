using S8__Complet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8__Complet.Repository
{
    internal interface IDonneeRepository: IDisposable
    {
        IEnumerable<Donnees> GetDonnee();
        List<String> GetDonneeName();
        Donnees GetDonneeByID(int donnee);
        void InsertDonnee(Donnees donnee);
        void DeleteDonnee(int donneeID);
        void UpdateDonnee(Donnees donnee);
        void Save();
    }
}
