using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class AllMembresias
    {
        string _fileMembresias = Path.Combine(FileSystem.AppDataDirectory, "Membresias.txt");
        public ObservableCollection<Membresias> CollectionMembresias { get; set; } = new ObservableCollection<Membresias>();
        public AllMembresias() => 
            LoadMembresias();
        public void LoadMembresias()
        {
            CollectionMembresias.Clear();

            IEnumerable<Membresias> _membresias= new List<Membresias>();
            string dataMembresias = File.ReadAllText(_fileMembresias);
            if (!string.IsNullOrEmpty(dataMembresias))
            {
                _membresias = JsonConvert.DeserializeObject<List<Membresias>>(dataMembresias);
            }

            foreach (Membresias membresia in _membresias)
            {
                CollectionMembresias.Add(membresia);
            }
        }
    }
}
