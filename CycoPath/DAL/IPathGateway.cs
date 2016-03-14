﻿using CycoPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycoPath.DAL
{
    interface IPathGateway
    {
        IEnumerable<Path> SelectALL();
        IEnumerable<Path> SearchPath(List<string> listString);
        Path SelectById(int? id);
        void Insert(Path path);
        void Update(Path path);
        Path Delete(int? id);
        void Save();
    }
}
