using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using CLIMB.Models;

namespace CLIMB.DataAccess
{
    public class CvDB
    {
        public string Connectionstring = ConfigurationManager.ConnectionStrings["climbDB"].ConnectionString;

        public IEnumerable<MaterialTypeModel> GetMaterialTypes()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var materialTypes = sqlConnection.Query<MaterialTypeModel>("SELECT * FROM cv_MaterialType");
                return materialTypes;

            }
        }
        public IEnumerable<EventTypeModel> GetEventTypes()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var eventTypes = sqlConnection.Query<EventTypeModel>("SELECT * FROM cv_EventType");
                return eventTypes;

            }
        }
    }
}
