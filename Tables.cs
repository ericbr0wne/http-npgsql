using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using System.Net;
using System.IO;
using http_npgsql;


namespace http_npgsql;

public class Tables(NpgsqlDataSource db)
{

    public async Task Create()
    {

        const string qUsers = @"
        CREATE TABLE IF NOT EXISTS Users(
            user_id SERIAL PRIMARY KEY,
            username TEXT NOT NULL,
            password TEXT NOT NULL)";

        await db.CreateCommand(qUsers).ExecuteNonQueryAsync();

    }
}

        /*
        }


         (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS test(value TEXT)"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("INSERT INTO test (value) VALUES ($1)"))
{
    cmd.Parameters.AddWithValue("Hello, World!");
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("SELECT * FROM test"))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
    {
        Console.WriteLine(reader.GetString(0));
    }
}

        */

