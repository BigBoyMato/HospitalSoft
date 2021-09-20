using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace Classes
{
    public class Repository
    {
        public static string fullPath = Environment.CurrentDirectory;
        public static string newPath = Path.GetFullPath(Path.Combine(fullPath, @"..\..\..\"));
        public string filePathDoctors = Path.Combine(newPath, "Classes\\JsonRepository\\doctors.json");
        public string filePathPacients = Path.Combine(newPath, "Classes\\JsonRepository\\pacients.json");

        public List<userPacient> userPacients { get; set; }
        public List<userDoctor> userDoctors { get; set; }

        public event Action OnAppointmentDataChanged;

        public userPacient CurrentPacient { get; set; }
        public userDoctor CurrentDoctor { get; set; }

        public Repository()
        {
            ReadData();
            CurrentPacient = userPacients[0];
            CurrentDoctor = userDoctors[0];
        }
        public bool AuthorizePacient(string login, string password)
        {
            CurrentPacient = userPacients.FirstOrDefault(u => u.Login == login && u.Password == password);
            return CurrentPacient != null;
        }
        public bool AuthorizeDocotor(string login, string password)
        {
            CurrentDoctor = userDoctors.FirstOrDefault(u => u.Login == login && u.Password == password);
            return CurrentDoctor != null;
        }
        public void AddAppointment(Appointment appointment)
        {
            CurrentPacient.Appointments.Add(appointment);
            OnAppointmentDataChanged?.Invoke();
        }
        public void RemoveAppointment(Appointment appointment)
        {
            CurrentPacient.Appointments.Remove(appointment);
            OnAppointmentDataChanged?.Invoke();
        }
        public List<T> ReadList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
        public void ReadData()
        {
            userDoctors = ReadList<userDoctor>(filePathDoctors);
            userPacients = ReadList<userPacient>(filePathPacients);
        }
        public void SaveList<T>(string fileName, List<T> data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer()
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }
        public void SaveData(List<userDoctor> userDoctors, List<userPacient> userPacients)
        {
            SaveList(filePathDoctors, userDoctors);
            SaveList(filePathPacients, userPacients);
        }

       

        // DELETE SYNC. NOT FINISHED (no file rewriting)
        
        /*
        public void DeleteDataDoctors(Appointment appointment)
        {
            List<userDoctor> newuserDoctors = new List<userDoctor>();
            var data = ReadList<userDoctor>(filePathDoctors);
            foreach (var doc in data)
            {
                if (doc.Name == appointment.DoctorName)
                {
                    for (var i = 0; i < doc.Appointments.Count; i++)
                    {
                        if (doc.Appointments[i].AppDate == appointment.AppDate && doc.Appointments[i].PacientName == appointment.PacientName)
                        {
                            var aPP = doc.Appointments[i];
                            doc.Appointments.Remove(aPP);
                            newuserDoctors.Add(doc);
                        }
                    }
                }
            }
        }*/



    }
}
