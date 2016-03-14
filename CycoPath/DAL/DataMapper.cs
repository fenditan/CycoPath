using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;

namespace CycoPath.DAL
{
    public class DataMapper : IDataMapper
    {
        private PathGateway pathGateway = new PathGateway();
        private ParkGateway parkGateway = new ParkGateway();

        public IEnumerable<Park> SelectALLPark()
        {
            return parkGateway.SelectALL();
        }

        public Park SelectParkById(int? id)
        {
            return parkGateway.SelectById(id);
        }

        public IEnumerable<Park> SearchPark(List<string> listString)
        {
            return parkGateway.SearchPark(listString);
        }

        public IEnumerable<Path> SelectALLPath()
        {
            return pathGateway.SelectALL();
        }

        public Path SelectPathById(int? id)
        {
            return pathGateway.SelectById(id);
        }

        public IEnumerable<Path> SearchPath(List<string> listString)
        {
            return pathGateway.SearchPath(listString);
        }
    }
}