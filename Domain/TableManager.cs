using System.Collections;

namespace Domain;


public static class TableManager 
{
  public readonly static uint TableCapacity = 100;

  private static Hashtable Table = new Hashtable((int)TableCapacity);

  /// <summary>
  /// Attempt to Get a data string from the table.
  /// </summary>
  /// <param name="key">The key of the data you are requesting</param>
  /// <returns>The data or null if the data does not exist</returns>
  public static string? Get(ulong key) {
    return (string?)Table[key];
  }

  /// <summary>
  /// Attempt to Add a data string to the table. It will request a hash for the data.
  /// </summary>
  /// <param name="data">The string to add</param>
  /// <returns>The hash or null if the data already exists</returns>
  public static ulong? Add(string data) {
    var hash = calculateHash(data);
    if (Table.Contains(hash)) {
      return null;
    }

    Table.Add(hash, data);
    return hash;
  }

  /// <summary>
  /// Method to calculate hash from string. The algorithm is a folding algorithm where the string is divided into sections of 4 bytes.
  /// Each section of 4 bytes is added together. In the end the modulus function will map it to the range of the hash table.
  /// </summary>
  /// <param name="data">The string to hash</param>
  /// <returns>A hash that is mapped to the table size</returns>
  private static ulong calculateHash(string data) {
    ulong sum = 0;
    ulong mul = 1;

    for (int i = 0; i < data.Length; i++) {
      mul = (i % 4 == 0) ? 1 : mul * 256;
      sum += data.ElementAt<char>(i) * mul;
    }

    return sum % TableCapacity;
  }
}
