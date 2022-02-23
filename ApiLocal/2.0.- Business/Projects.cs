using ApiLocal._0._0_._Entities.General.Response;
using ApiLocal._0._0_._Entities.Project.Response;
using ApiLocal._1._0_._Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLocal._2._0.__Business
{
    public class Projects
    {
        private ValuesRepository _valuesRepository;
        private readonly IConfiguration _configuration;


        public Projects(ValuesRepository valuesRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _valuesRepository = valuesRepository;
        }

        public ResponseAll GetProjects(HttpContext _http)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();   
            return ApiLocal.Utilities.Utilities.GetCat<Project>(_valuesRepository, data, "getAmbientes", getConnection(_http));
        }

        private string getConnection(HttpContext _http) {
            string privateKeyFile = Directory.GetCurrentDirectory() + _configuration["RouteKeyPrivate"];
            string stringConnection = ApiLocal.Utilities.Utilities.getConnection(_http, privateKeyFile);
            if (stringConnection == null) {
                throw new Exception("No se encontro ninguna cadena de conexion");
            }
            return stringConnection;
        }

    }
}
