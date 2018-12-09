using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneRHinventorysystem
{
    public class Guitar
    {
        public enum GuitarBrand
        {
            Fender,
            Gibson,
            Squire,
            Epiphone,
            Charvel,
            Warmoth,
            Rickenbacker,
            Custom

        }


        #region Fields
        private string _model;
        private double _weight;
        private bool _isElectric;
        private GuitarBrand _guitarBrand;
        private string _countryMadeIn;
        private double _numberOfStrings;











        #endregion






        #region Properties
        public bool IsElectric 
        {
            get { return _isElectric; }
            set { _isElectric = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public GuitarBrand Brand
        {
            get { return _guitarBrand; }
            set { _guitarBrand = value; }
        }
        public string CountryMadeIn
        {
            get { return _countryMadeIn; }
            set { _countryMadeIn = value; }
        }
        public double NumberOfStrings
        {
            get { return _numberOfStrings; }
            set { _numberOfStrings = value; }
        }
        #endregion

        #region constructors
        public Guitar()
        {

        }
        public Guitar(string model)
        {
            _model = model;
        }

        #endregion

        public string SeaMonsterAttitude()
        {
            return _model + "is" + _guitarBrand + " guitar.";
        }
    }
}
