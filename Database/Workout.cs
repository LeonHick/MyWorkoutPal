using SQLite;
namespace MyWorkoutPal.Model
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Day { get; set; }
    }
}
 