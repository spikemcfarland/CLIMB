using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using CLIMB.Models;

namespace CLIMB.DataAccess
{
    public class MaterialDB
    {
        public string Connectionstring = ConfigurationManager.ConnectionStrings["climbDB"].ConnectionString;

        public IEnumerable<MaterialModel> GetMaterials()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var animal = sqlConnection.Query<MaterialModel>("SELECT * FROM Material");
                return animal;

            }
        }
        public MaterialModel GetMaterialByKey(int animalKey)
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                string strQuery = string.Format("SELECT * FROM Material WHERE _Material_key={0}", animalKey);
                var animal = sqlConnection.Query<MaterialModel>(strQuery).Single<MaterialModel>();
                return animal;

            }
        }
        public MaterialModel GetEventMaterials(int eventKey)
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                string strQuery = string.Format("SELECT * FROM Material WHERE _Material_key IN (SELECT _Material_key FROM EventMaterial WHERE _Event_key={0}", eventKey);
                var animal = sqlConnection.Query<MaterialModel>(strQuery).Single<MaterialModel>();
                return animal;

            }
        }
        public string Create(MaterialModel materialEntity)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
                {
                    sqlConnection.Open();

                    string sqlQuery = "INSERT INTO Material(_MaterialType_key,MaterialID,MaterialName,_Workgroup_key,CreatedBy,DateCreated,ModifiedBy,DateModified) VALUES (@_MaterialType_key,@MaterialID,@MaterialName,@_Workgroup_key,@CreatedBy,@DateCreated,@ModifiedBy,@DateModified)";
                    sqlConnection.Execute(sqlQuery,
                                          new
                                          {
                                              materialEntity._MaterialType_key,
                                              materialEntity.MaterialID,
                                              materialEntity.MaterialName,
                                              materialEntity._Workgroup_key,
                                              materialEntity.CreatedBy,
                                              materialEntity.DateCreated,
                                              materialEntity.ModifiedBy,
                                              materialEntity.DateModified
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
        public bool Update(MaterialModel animalEntity)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
                {
                    sqlConnection.Open();
                    string sqlQuery = "UPDATE Material SET _MaterialType_key=@_MaterialType_key,MaterialID=@MaterialID,MaterialName=@MaterialName WHERE _Material_key=@_Material_key";
                    sqlConnection.Execute(sqlQuery, new
                    {
                        animalEntity._MaterialType_key,
                        animalEntity.MaterialID,
                        animalEntity.MaterialName,
                        animalEntity._Material_key
                    });
                    sqlConnection.Close();

                }
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }        
        public bool Delete(int animalKey)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
                {
                    sqlConnection.Open();
                    string sqlQuery = string.Format("DELETE FROM Material WHERE _Material_key={0}", animalKey);
                    sqlConnection.Execute(sqlQuery);
                    sqlConnection.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}