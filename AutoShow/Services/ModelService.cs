using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace AutoShow.Services
{
    class ModelService : IModelService
    {
        private AutoShowDb _autoShowDb;

        public ModelService()
        {
            _autoShowDb = new AutoShowDb();
        }

    }
}
