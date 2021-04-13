using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Search;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using System.IO;

namespace GroupProjectCovid
{
    public class CountryViewModel
    {

        public ObservableCollection<CountryModel> Files { get; set; }
        public List<CountryModel> _allFiles = new List<CountryModel>();
        public event PropertyChangedEventHandler PropertyChanged;
        private CountryModel _selectedFile;
        private string _filter;

        public string countryName { get; set; }
        public string countryPop { get; set; }
        public string countryCapitol { get; set; }

        public string totalCases { get; set; }
        public string totalRecovered { get; set; }
        public string totalDeaths { get; set; }

        public string totalVacines { get; set; }
        public string totalPartialVacines { get; set; }
        public string totalUnvaccinated { get; set; }


        public CountryModel SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;
                //If the file is empty
                if (value == null)
                { //Ouput that its empty

                }
                else //Set its text to the files text
                {
                    countryName = value.countryName;
                    countryCapitol = value.countryCapitol;
                    countryPop = value.countryPop;
                    totalCases = value.cTotalCases;
                    totalRecovered = value.cTotalRecovered;
                    totalDeaths = value.cTotalDeaths;



                }

                //TODO Property for starter pages variables
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FileText"));

            }
        }

        public CountryViewModel()
        {
            
            //Create the colelction
            Files = new ObservableCollection<CountryModel>();

            //Create the collection
            CreateCollection();

            //Perform Filtering
            PerformFiltering();
        }


        public async void CreateCollection()
        {
            _allFiles.Clear();
            Files.Clear();

            _allFiles = FetchData.GetData();

            PerformFiltering();
        }


        public void PerformFiltering()
        {
            Files.Clear();

            //If filter is null set it to ""
            if (_filter == null)
            {
                _filter = "";
            }
            //If _filter has a value (ie. user entered something in Filter textbox)
            //Lower-case and trim string
            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();

            //Use LINQ query to get all personmodel names that match filter text, as a list
            var result =
                _allFiles.Where(d => d.countryName.ToLowerInvariant()
                .Contains(lowerCaseFilter))
                .ToList();

            //Get list of values in current filtered list that we want to remove
            //(ie. don't meet new filter criteria)
            var toRemove = Files.Except(result).ToList();

            //Loop to remove items that fail filter
            foreach (var x in toRemove)
            {
                Files.Remove(x);
            }

            var resultCount = result.Count;

            // Add back in correct order.
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Files.Count || !Files[i].Equals(resultItem))
                {
                    Files.Insert(i, resultItem);
                }
            }
        }


        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter) { return; }
                _filter = value;
                PerformFiltering();
                //Invovoked whenever the property is changed
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
            }
        }





    }
}
