using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharp_7
{
    class ValueTask
    {
        public ConcurrentDictionary<string, Person> _Cache { get; set; }

        public async ValueTask<Person> ReadFromCacheAsync(string key)
        {
            if (_Cache.TryGetValue(key, out Person result)) //out self declring
            {
                return result; //no allocation
            }
            else
            {
                result = await ReadFromDBAsync(key);
                _Cache.TryAdd(key, result);
                return result;
            }
        }

        public async Task<Person> ReadFromDBAsync(string id)
        {
            Person p = null;
            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection("connString"))
                {
                    using (SqlCommand command = new SqlCommand($"select * from Person where id={id}", conn))
                    {
                        await conn.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                p = new Person(reader["Name"].ToString());
                            }
                        }
                    }
                }
                transaction.Complete();
            }
            return p;
        }


    }
}
