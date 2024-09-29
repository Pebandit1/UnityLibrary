using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataService
{
    public abstract class DataServiceException : System.Exception { }

    public class FileInexistantException : DataServiceException
    {
        string fn;
        DateTime time;
        public FileInexistantException(string fn)
        {
            this.fn = fn;
            time = DateTime.Now;
        }

        public override string ToString()
            => $"{time.ToString()}, File {fn} doesn't exist";
    }
}
