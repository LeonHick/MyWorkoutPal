using SQLite;
namespace MyWorkoutPal.Model
{
    public class Graph
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Day { get; set; }
        public string Workout { get; set; }
        public string Exercise { get; set; }
        public string Weight { get; set; }
    }
}