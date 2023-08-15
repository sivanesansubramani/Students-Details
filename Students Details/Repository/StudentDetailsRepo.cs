using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students_Details.Models;
using System.Data.SqlClient;
using Dapper;

namespace Students_Details.Repository
{
    public class StudentDetailsRepo
    {


        public readonly string connectionString;


        public StudentDetailsRepo()
        {

            connectionString = @"Data Source = DESKTOP-8VD1A1F\SQLEXPRESS; Initial Catalog = Student details; User Id=sa;Password=Anaiyaan@123";
        }

        /*public Studentmodels DynamicDataModel()
        {
            Studentmodels ObjPersonalBio = new Studentmodels();

            Console.WriteLine("enter id");
            ObjPersonalBio.id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter fist name");
            ObjPersonalBio.Name = Console.ReadLine();

            Console.WriteLine("enter your last name name");
            ObjPersonalBio.LastName = Console.ReadLine();

            Console.WriteLine("enter age");
            ObjPersonalBio.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter address");
            ObjPersonalBio.Address = Console.ReadLine();


            return ObjPersonalBio;
        }*/


        public void InsertStudentDetails(Studentmodels bio)
        {
            try
            {


        SqlConnection connectionObject = new SqlConnection(connectionString);

                connectionObject.Open();
                connectionObject.Execute($"Exec Insertdetalis '{bio.Firstname}', '{bio.Mailid}',{bio.Mobilenumber},'{bio.classname}','{bio.Fathername}','{bio.Mothername}' ");


                connectionObject.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Studentmodels> Select()

        {
            try
            {
                List<Studentmodels> ListofPersonalData = new List<Studentmodels>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<Studentmodels>("Exec Selectdetails", connectionString).ToList();
                connection.Close();



                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }








        public void ubdate(Studentmodels bio)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);



                connectionObject.Open(); // Age = @Age, Address = @Address where id = @id

                connectionObject.Execute($"  Exec Updatedetails {bio.Studid},'{bio.Firstname}', '{bio.Mailid}',{bio.Mobilenumber},'{bio.classname}','{bio.Fathername}','{bio.Mothername}'");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void delete(int Studid)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);

                /* Console.WriteLine("enter a id  to delete record");
                 int del = Convert.ToInt32(Console.ReadLine());
 */
                connectionObject.Open();
                connectionObject.Execute($"Exec Deletedetails {Studid} ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public Studentmodels SelectSP(int Studid)
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                var res = connection.QueryFirst<Studentmodels>($"exec selectwithID {Studid}");
                connection.Close();

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
