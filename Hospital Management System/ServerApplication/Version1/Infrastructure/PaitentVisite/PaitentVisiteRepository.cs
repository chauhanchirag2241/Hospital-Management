﻿using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class PaitentVisiteRepository : IPaitentVisiteRepository
    {
        private IConfiguration _configuration;

        public PaitentVisiteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> createVisite(paitentvisite paitentvisite)
        {
            try
            {
                SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
               

                DynamicModelConverter<paitentvisite> converter = new DynamicModelConverter<paitentvisite>();
                int visiteAdded = converter.Insert(connecion.ConnectionString, paitentvisite);

                
                return visiteAdded;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}