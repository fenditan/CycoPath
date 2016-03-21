using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;
using CycoPath.Services;

namespace CycoPath.DAL
{
    public class DataMapper : IDataMapper
    {
        private IPathGateway pathGateway = new PathGateway();
        private IParkGateway parkGateway = new ParkGateway();
        private WeatherGateway weatherGateway = new WeatherGateway();

        List<CycoPathModel> listModel = new List<CycoPathModel>();

        public ICollection<CycoPathModel> SearchAllParksPath(List<string> listString){

            IEnumerable<Park> park = parkGateway.SearchPark(listString);
            
            foreach (Park parkSingle in park)
            {
                Path pathSingle = pathGateway.SearchPath(parkSingle.Name);
                CycoPathModel model = new CycoPathModel();
                model.ParkViewModel = parkSingle;
                model.PathViewModel = pathSingle;
                listModel.Add(model);
            }
            return listModel;
        }

        public IEnumerable<Park> SelectAllPark()
        {
            return parkGateway.SelectALL();
        }

        //public Park SelectParkById(int? id)
        //{
        //    return parkGateway.SelectById(id);
        //}

        public IEnumerable<Park> SearchPark(List<string> listString)
        {
            return parkGateway.SearchPark(listString);
        }

        public IEnumerable<Path> SelectAllPath()
        {
            return pathGateway.SelectALL();
        }

        public Weather getParkWeather(string coordinates)
        {
            return weatherGateway.getParkWeather(coordinates);
        }

        //public Path SelectPathById(int? id)
        //{
        //    return pathGateway.SelectById(id);
        //}

        //public IEnumerable<Path> SearchPath(List<string> listString)
        //{
        //    return pathGateway.SearchPath(listString);
        //}
    }
}