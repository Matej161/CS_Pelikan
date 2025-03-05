using System.Data.Common;
using MySqlConnector;

namespace RPGApp.DAL;

public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "matej.kulisek";
    public string Password = "";
    public string Database = "student_matej.kulisek_RPGApp";

    public string connectionString =>
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};Port=3306;";

    public Exception? ThrownException;

    public DBDriver(string password)
    {
        Password = password;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public List<Enemy> GetAllEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = "SELECT * FROM enemy";
            MySqlCommand command = new MySqlCommand(query, connection);
            // execute reader
            var reader = command.ExecuteReader();
            // while reader.next
            while (reader.Read())
            {
                // create new enemy
                var Enemy = new Enemy();
                Enemy.Id = reader.GetGuid(0);
                Enemy.Name = reader.GetString(1);
                Enemy.Health = reader.GetInt16(2);
                Enemy.Damage = reader.GetInt16(3);
                Enemy.Armor = reader.GetInt16(4);
                Enemy.CriticalChance = reader.GetFloat(5);
                Enemy.CriticalScaler = reader.GetFloat(6);
                
                enemies.Add(Enemy);
            }
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }

        // return list
        return enemies;
    }

    public void InsertUser(Enemy enemy)
    {
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = @"INSERT INTO enemy VALUES (@id, @name, @health, @damage, @armor, @criticalChance, @criticalScaler);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", enemy.Id);
            command.Parameters.AddWithValue("@name", enemy.Name);
            command.Parameters.AddWithValue("@health", enemy.Health.ToString());
            command.Parameters.AddWithValue("@damage", enemy.Damage.ToString());
            command.Parameters.AddWithValue("@armor", enemy.Armor.ToString());
            command.Parameters.AddWithValue("@criticalChance", enemy.CriticalChance.ToString());
            command.Parameters.AddWithValue("@criticalScaler", enemy.CriticalScaler.ToString());
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }
    }
    
}