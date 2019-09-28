using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester1Project
{
    public class DataHolder
    {
        private Dictionary<string, Dictionary<string, Dictionary<string, Formula>>> Data = new Dictionary<string, Dictionary<string, Dictionary<string, Formula>>>
        {
            ["Математика"] = new Dictionary<string, Dictionary<string, Formula>>
            {
                ["Площади"] = new Dictionary<string, Formula>
                {
                    ["Формула Герона"] = new Formula("Формула Герона", "S = sqrt(p * (p - a) * (p - b) * (p - c))", "p - полупериметр.\nВычисление площади треугольника по 3м сторонам."),
                    ["Площадь треугольника"] = new Formula("Площадь треугольника", "S = 1/2 * a * h", "Вычисление площади через сторону и высоту к этой стороне")
                },
                ["Треугольники"] = new Dictionary<string, Formula>()
            },
            ["Физика"] = new Dictionary<string, Dictionary<string, Formula>>
            {
                ["Механика"] = new Dictionary<string, Formula>(),
                ["Движение"] = new Dictionary<string, Formula>()
            }
        };

        public List<string> GetSubjects()
        {
            var result = new List<string>();
            foreach (var str in Data.Keys)
            {
                result.Add(str);
            }
            return result;
        }

        public List<string> GetSections(string subject)
        {
            var result = new List<string>();
            foreach (var str in Data[subject].Keys)
            {
                result.Add(str);
            }
            return result;
        }

        public List<string> GetFormulas(string subject, string section)
        {
            var result = new List<string>();
            foreach (var str in Data[subject][section].Keys)
            {
                result.Add(str);
            }
            return result;
        }

        public List<string> GetFormulaDescrption(string subject, string section, string formula)
        {
            var result = new List<string>();
                result.Add(Data[subject][section][formula].name);
                result.Add(Data[subject][section][formula].formula);
                result.Add(Data[subject][section][formula].description);
            return result;
        }

        public void AddSubject(string name)
        {
            var key = name.Split('\n');
            if (!Data.ContainsKey(key[0]))
            {
                Data.Add(key[0], new Dictionary<string, Dictionary<string, Formula>>());
            }
        }

        public void AddSection(string name)
        {
            var key = name.Split('\n');
            if (!Data.ContainsKey(key[0]))
            {
                MessageBox.Show("Ввдённого предмета не существует.");
                return;
            }
            if (!Data[key[0]].ContainsKey(key[1]))
            {
                Data[key[0]].Add(key[1], new Dictionary<string, Formula>());
            }
        }

        public void AddFormula(string buffer)
        {
            var key = buffer.Split('\n');
            if (!Data.ContainsKey(key[0]))
            {
                MessageBox.Show("Ввдённого предмета не существует.");
                return;
            }
            if (!Data[key[0]].ContainsKey(key[1]))
            {
                MessageBox.Show("Введённого раздела не существует.");
                return;
            }
            if (!Data[key[0]][key[1]].ContainsKey(key[2]))
            {
                Data[key[0]][key[1]].Add(key[2], new Formula(key[2], key[3], key[4]));
            }
        }

    }
}
