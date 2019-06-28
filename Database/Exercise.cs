using SQLite;
namespace MyWorkoutPal.Model
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Workout { get; set; }
        public string Name { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Weight { get; set; }
    }
}
