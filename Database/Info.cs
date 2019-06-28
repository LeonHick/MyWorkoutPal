using SQLite;
namespace MyWorkoutPal.Model
{
    public class Info
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bench { get; set; }
        public string Squat { get; set; }
        public string Dead { get; set; }
        public string Ohp { get; set; }
        public string BenchActual { get; set; }
        public string SquatActual { get; set; }
        public string DeadActual { get; set; }
        public string OhpActual { get; set; }
        public string Unit { get; set; }
        public string Month { get; set; }
        public string x { get; set; }
        public string Upper { get; set; }
        public string Lower { get; set; }
        public string Week { get; set; }
        public string Workout { get; set; }
        public int Days { get; set; }
    }
}