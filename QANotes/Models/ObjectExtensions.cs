using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace QANotes.Models
{
    public static class ObjectExtensions
    {
        public static string Jsonify(this object obj)
        {
            JsonSerializer js = JsonSerializer.Create();
            var jw = new StringWriter();
            js.Serialize(jw, obj);
            return jw.ToString();
        }

        public static NotesViewModel UnJsonify(this object obj)
        {
            //TODO convert json to NotesViewModel
            //http://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm

            throw new NotImplementedException();
        }
    }
}