using Microsoft.EntityFrameworkCore;
using qulix_data.Data;
using qulix_repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Data;

namespace qulix_repo
{
    public class TextRepository : Repository<Text>, ITRepository
    {
        public TextRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Text text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            _context.ChangeTracker.Clear();
            _entities.Attach(text);
            _context.Entry(text).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void SaveInCsv(IEnumerable<Text> text, string filepath)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text", "Value can not be null or Nothing!");
            }

            var dataTable = new DataTable(typeof(Text).Name);
            PropertyInfo[] props = typeof(Text).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (var prop in props)
                dataTable.Columns.Add(prop.Name, prop.PropertyType);

            foreach (var txt in text)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(txt, null);
                }
                dataTable.Rows.Add(values);
            }

            StringBuilder fileContent = new StringBuilder();
            foreach (var col in dataTable.Columns)
                fileContent.Append(col.ToString() + ",");

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                    fileContent.Append("\"" + column.ToString() + "\",");

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }


            if (!System.IO.File.Exists(filepath))
            {
                System.IO.File.Create(filepath);
                System.IO.File.WriteAllText(filepath, fileContent.ToString());
            }
            else
            {
                System.IO.File.WriteAllText(filepath, fileContent.ToString());
            }
        }
    }
}
