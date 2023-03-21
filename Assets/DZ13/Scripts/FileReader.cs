using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public static class FileReader
{
    public static async Task<string> Read(string fileName)
    {
        return await System.IO.File.ReadAllTextAsync(Application.dataPath + "/DZ13/Text/" + fileName);
    }
}
