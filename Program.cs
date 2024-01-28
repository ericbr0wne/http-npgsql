using http_npgsql;
using Npgsql;
using System.Data;

const string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=ericDB";

await using var db = NpgsqlDataSource.Create(dbUri);

var tables = new Tables(db);
await tables.Create();