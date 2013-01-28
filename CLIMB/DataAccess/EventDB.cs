using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using CLIMB.Models;

namespace CLIMB.DataAccess
{
    public class EventDB
    {
        public string Connectionstring = ConfigurationManager.ConnectionStrings["climbDB"].ConnectionString;

        public IEnumerable<EventModel> GetEvents()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var event_ = sqlConnection.Query<EventModel>("SELECT * FROM Event");
                return event_;
            }
        }
        public IEnumerable<EventModel> GetRelatedEvents(int eventKey)
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var animal = sqlConnection.Query<EventModel>("SELECT * FROM Event WHERE _Event_key IN (SELECT _RelatedEvent_key FROM EventMap WHERE _Event_key={0})", eventKey);
                return animal;
            }
        }
        public string Create(EventModel eventEntity)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
                {
                    sqlConnection.Open();

                    string sqlQuery = "INSERT INTO Event(_EventType_key,EventID,EventName,ProjectedDate,ActualDate,_Workgroup_key,CreatedBy,DateCreated,ModifiedBy,DateModified) VALUES (@_EventType_key,@EventID,@EventName,@ProjectedDate,@ActualDate,@_Workgroup_key,@CreatedBy,@DateCreated,@ModifiedBy,@DateModified)";
                    sqlConnection.Execute(sqlQuery,
                                          new
                                          {
                                              eventEntity._EventType_key,
                                              eventEntity.EventID,
                                              eventEntity.EventName,
                                              eventEntity.ProjectedDate,
                                              eventEntity.ActualDate,
                                              eventEntity._Workgroup_key,
                                              eventEntity.CreatedBy,
                                              eventEntity.DateCreated,
                                              eventEntity.ModifiedBy,
                                              eventEntity.DateModified
                                          });


                    sqlConnection.Close();

                }
                return "Created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}