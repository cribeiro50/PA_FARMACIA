using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class Farmacia : INotifyPropertyChanged
    {
        #region Construtores

        public Farmacia()
        {
            this.FarmaciaID = 1;
            this.NomeFarmacia = "Farmacia";
            this.Endereco = "Rua";
        }

        public Farmacia(long farmaciaID, string nomeFarmacia, string endereco)
        {
            this.FarmaciaID = farmaciaID;
            this.NomeFarmacia = nomeFarmacia;
            this.Endereco = endereco;
        }

        #endregion

        #region Propriedades

        private long farmaciaID;
        public long FarmaciaID
        {
            get => farmaciaID;
            set
            {
                farmaciaID = value;
                OnPropertyChanged(nameof(FarmaciaID));
            }
        }

        private string nomeFarmacia;
        public string NomeFarmacia
        {
            get => nomeFarmacia;
            set
            {
                nomeFarmacia = value;
                OnPropertyChanged(nameof(NomeFarmacia));
            }
        }

        private string endereco;
        public string Endereco
        {
            get => endereco;
            set
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }

        public override string ToString()
        {
            return $"Farmacia: {FarmaciaID} - {NomeFarmacia} - {Endereco}";
        }

        #endregion

        #region Eventos e Métodos

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static DataTable GetList(string filter)
        {
            return DataLayer.Farmacia.GetList(filter);
        }

        public static FarmaciaCollection GetListBottles(string filter)
        {
            DataTable dataTable = GetList(filter);
            return new FarmaciaCollection(dataTable);
        }

        #endregion
    }

    public class FarmaciaCollection : ObservableCollection<Farmacia>
    {
        public FarmaciaCollection() { }

        public FarmaciaCollection(DataTable dataTable)
        {
            if (dataTable == null) return;

            foreach (DataRow item in dataTable.AsEnumerable())
            {
                Add(new Farmacia
                {
                    
                    NomeFarmacia = item.Field<string>("NomeFarmacia"),
                    
                });
            }
        }
    }
}
