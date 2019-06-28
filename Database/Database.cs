using Android.Util;
using SQLite;
using MyWorkoutPal.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyWorkoutPal.Resources.Helper
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    connection.CreateTable<Exercise>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabaseGraph()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Graph.db")))
                {
                    connection.CreateTable<Graph>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabaseWorkout()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.CreateTable<Workout>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabaseInfo()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    connection.CreateTable<Info>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabasePull()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    connection.CreateTable<Exercise>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabasePush2()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    connection.CreateTable<Exercise>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabasePull2()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    connection.CreateTable<Exercise>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool createDatabaseLegs()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    connection.CreateTable<Exercise>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  

        public bool insertIntoTable(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    connection.Insert(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool insertIntoTableGraph(Graph graph)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Graph.db")))
                {
                    connection.Insert(graph);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool insertIntoTableWorkout(Workout workout)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.Insert(workout);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool insertIntoTableInfo(Info info)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    connection.Insert(info);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool insertIntoTablePull(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    connection.Insert(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoTablePush2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    connection.Insert(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoTablePull2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    connection.Insert(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoTableLegs(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    connection.Insert(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }


        public List<Exercise> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    return connection.Table<Exercise>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Graph> selectTableGraph()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Graph.db")))
                {
                    return connection.Table<Graph>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        //ive fucked around below
        public List<Info> selectTableInfo()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    return connection.Table<Info>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Workout> selectTableWorkout()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    return connection.Table<Workout>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Exercise> selectTablePull()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    return connection.Table<Exercise>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Exercise> selectTablePush2()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    return connection.Table<Exercise>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Exercise> selectTablePull2()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    return connection.Table<Exercise>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Exercise> selectTableLegs()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    return connection.Table<Exercise>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Edit Operation  

        public bool updateTable(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    connection.Query<Exercise>("UPDATE exercise set Name=?, Sets=?, Reps=?, Weight=? Where Id=?", exercise.Name, exercise.Sets, exercise.Reps, exercise.Weight, exercise.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTableWorkout(Workout workout)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.Query<Workout>("UPDATE workout set Day=? Where Id=?", workout.Day, workout.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTableGraph(Graph graph)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Graph.db")))
                {
                    connection.Query<Workout>("UPDATE graph set Day=?, Workout=?, Exercise=?, Weight=? Where Id=?", graph.Day, graph.Workout, graph.Exercise, graph.Weight, graph.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTableInfo(Info info)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    connection.Query<Info>(
                        "UPDATE info set Name=?, Sex=?, Weight=?, Username=?, Password=?, " +
                        "Bench=?, Squat=?, Dead=?, Ohp=?, BenchActual=?, SquatActual=?, " +
                        "DeadActual=?, OhpActual=?, Unit=?, Month=?, x=?, Upper=?, Lower=?, Week=?, Workout=?, Days=? Where Id=?",
                        info.Name, info.Sex, info.Weight, info.Username, info.Password,
                        info.Bench, info.Squat, info.Dead, info.Ohp, info.BenchActual,
                        info.SquatActual, info.DeadActual, info.OhpActual, info.Unit, info.Month, info.x,
                        info.Upper, info.Lower, info.Week, info.Workout, info.Days, info.Id
                        );
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }


        public bool updateTablePull(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    connection.Query<Exercise>("UPDATE exercise set Name=?, Sets=?, Reps=?, Weight=? Where Id=?", exercise.Name, exercise.Sets, exercise.Reps, exercise.Weight, exercise.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTablePush2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    connection.Query<Exercise>("UPDATE exercise set Name=?, Sets=?, Reps=?, Weight=? Where Id=?", exercise.Name, exercise.Sets, exercise.Reps, exercise.Weight, exercise.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTablePull2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    connection.Query<Exercise>("UPDATE exercise set Name=?, Sets=?, Reps=?, Weight=? Where Id=?", exercise.Name, exercise.Sets, exercise.Reps, exercise.Weight, exercise.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool updateTableLegs(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    connection.Query<Exercise>("UPDATE exercise set Name=?, Sets=?, Reps=?, Weight=? Where Id=?", exercise.Name, exercise.Sets, exercise.Reps, exercise.Weight, exercise.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Delete Data Operation  

        public bool removeTable(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    connection.Delete(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool removeTableWorkout(Workout workout)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.Delete(workout);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //Delete Data Operation  

        public bool removeTable(Info info)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    connection.Delete(info);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool removeTablePull(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    connection.Delete(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool removeTablePush2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    connection.Delete(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool removeTablePull2(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    connection.Delete(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool removeTableLegs(Exercise exercise)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    connection.Delete(exercise);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //Select Operation  

        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Exercises.db")))
                {
                    connection.Query<Exercise>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }




        public bool selectTableWorkout(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.Query<Workout>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectTableWorkoutDay(string Day)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Workout.db")))
                {
                    connection.Query<Workout>("SELECT * FROM exercise Where Day=?", Day);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectTablePull(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull.db")))
                {
                    connection.Query<Exercise>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }


        public bool selectTablePush2(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPush2.db")))
                {
                    connection.Query<Exercise>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectTablePull2(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesPull2.db")))
                {
                    connection.Query<Exercise>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectTableLegs(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExercisesLegs.db")))
                {
                    connection.Query<Exercise>("SELECT * FROM exercise Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //Select Operation  

        public bool selectTableInfo(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Info.db")))
                {
                    connection.Query<Info>("SELECT * FROM info Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

    }
}