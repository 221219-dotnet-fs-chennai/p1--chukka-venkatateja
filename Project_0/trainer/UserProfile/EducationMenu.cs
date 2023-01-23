﻿using System;
using System.Data;
using datahandle;
using System.Text.RegularExpressions;
namespace UserProfile
{
    public class EducationMenu
    {
        public EducationMenu(int usid)
        {
            bool runner = true;
            while (runner)
            {
                Console.WriteLine("");
                Console.WriteLine("0 - Back");
                Console.WriteLine("1. Add_Education");
                Console.WriteLine("2. Update_Education");
                Console.WriteLine("3. Delete_Education");
                Console.WriteLine("4. View_Education");
                Console.WriteLine("");


                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        runner = false;
                        break;

                    case 1:
                        AddEdu ads = new AddEdu();
                        ads.EduAdder(usid);
                        break;
                    case 2:
                        UpdateEdu up = new UpdateEdu();
                        up.EduUpdate(usid);
                        break;
                    case 3:
                        DeleteEdu dl = new DeleteEdu();
                        dl.EduDelete(usid);
                        break;
                    case 4:
                        ViewEdu vs = new ViewEdu();
                        vs.EduView(usid);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;

                }


            }
        }
    }

    public class AddEdu
    {
        Regex regdate = new Regex(@"\d\d\d\d-(01|02|03|04|05|06|07|08|09|10|11|12)-[0|1|2|3]\d");

        public void EduAdder(int usid)
        {
            Console.WriteLine("Enter The College Name");
            string EduName = Console.ReadLine();

            Console.WriteLine("Enter The Course Name");
            string EduCourse = Console.ReadLine();

            Console.WriteLine("Enter the start date of your course in yyyy-mm-dd format");

            string EduStartDate = Console.ReadLine();

            if (regdate.IsMatch(EduStartDate))
            {
                EduStartDate = EduStartDate;
            }
            else
            {

                Console.WriteLine("Enter a valid date");
                Console.WriteLine("Enter the start date of your course in yyyy-mm-dd format");
                EduStartDate = Console.ReadLine();
            }

            Console.WriteLine("Enter the end date of your course in yyyy-mm-dd format ");
            string EduEndDate = Console.ReadLine();



            if (regdate.IsMatch(EduEndDate))
            {
                EduEndDate = EduEndDate;
            }
            else
            {

                Console.WriteLine("Enter a valid date");


                Console.WriteLine("Enter the end date of your course in yyyy-mm-dd format ");
                EduEndDate = Console.ReadLine();

            }



            Console.WriteLine("Enter your CGPA acquired in the given course");
            string EduCgpa = Console.ReadLine();


            SqlHandle sq = new SqlHandle();
            string skill_name = sq.SqlQueryWriterSkill($"INSERT INTO venkat.edu(institution_name,course_name,[start_date],[end_date],cgpa,us_id) VALUES('{EduName}','{EduCourse}','{EduStartDate}','{EduEndDate}','{EduCgpa}',{usid});");
            skill_name = sq.SqlQueryWriterSkill($"SELECT * from venkat.edu;");
            //Console.WriteLine(skill_no);
            if (skill_name == EduName)
            {
                Console.WriteLine("Education details Added Successfully");
            }
            else
            {
                Console.WriteLine("Unable to add Education details");
            }

            //                INSERT into venkat.skills(skill_name, skill_experience, us_id)
            //VALUES('Python', 20, 3);





        }
    }

    public class UpdateEdu
    {
        public void EduUpdate(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.edu_id,k.institution_name,k.course_name,k.start_date,k.end_date,k.cgpa from venkat.edu as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("EducationId    College_name  CourseName  StarDate  EndDate  CGPA/percentage ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");


            Console.WriteLine("Enter the EducationId to update");
            int res = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Institution Name to Update");
            string resname = Console.ReadLine();

            Console.WriteLine("Enter the CourseName Name to Update");
            string rescourse = Console.ReadLine();

            Console.WriteLine("Enter the Start date to Update in yyyy-mm-dd format");
            string resstartdate = Console.ReadLine();

            Console.WriteLine("Enter the End date to Update in yyyy-mm-dd format");
            string resenddate = Console.ReadLine();

            Console.WriteLine("Enter the CGPA you want to update");
            string rescgpa = Console.ReadLine();

            //            UPDATE venkat.skills
            //SET skill_name = 'helloworld', skill_experience = 21
            //WHERE skill_id = 12;

            sq.sqlQueryDelete($"UPDATE venkat.edu SET institution_name = '{resname}',course_name = '{rescourse}',start_date = '{resstartdate}',end_date = '{resenddate}',cgpa = '{rescgpa}' WHERE edu_id = {res};");
            Console.WriteLine("Update Success");
        }
    }

    public class DeleteEdu
    {
        public void EduDelete(int usid)
        {
            SqlHandle sq = new SqlHandle();

            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.edu_id,k.institution_name,k.course_name,k.start_date,k.end_date,k.cgpa from venkat.edu as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("EducationId    College_Name  CourseName  StarDate  EndDate  CGPA ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            Console.WriteLine("Enter the EducationId you want to delete");
            int skill_id = Convert.ToInt32(Console.ReadLine());
            sq.sqlQueryDelete($"DELETE FROM venkat.edu WHERE edu_id ={skill_id}");
            Console.WriteLine("Deleted SuccessFully");


        }
    }

    public class ViewEdu
    {
        public void EduView(int usid)
        {
            SqlHandle sq = new SqlHandle();
            DataTable reader = sq.SqlQeryWriterSkillUpdate($"select k.edu_id,k.institution_name,k.course_name,k.start_date,k.end_date,k.cgpa from venkat.edu as k WHERE k.us_id = {usid};");
            //Console.WriteLine(reader);
            Console.WriteLine("EducationId     College_Name     CourseName     StarDate     EndDate    CGPA ");
            Console.WriteLine("");

            foreach (DataRow dataRow in reader.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
    }
}

