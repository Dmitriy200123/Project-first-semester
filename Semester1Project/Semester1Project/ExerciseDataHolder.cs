using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester1Project
{
    public class ExerciseDataHolder
    {
        private List<string> Subjects = new List<string> { "Математика", "Физика" };

        private Dictionary<string, Dictionary<string, Exercise>> Exercises = new Dictionary<string, Dictionary<string, Exercise>>
        {
            ["Математика"] = new Dictionary<string, Exercise>
            {
                ["Задача 1"] = new Exercise("Задача 1", "Условие Задачи", "Комментарий к формату ответа", new [] { "Подскзка 1", "Подсказка 2", "Подсказка 3" })
            },
            ["Физика"] = new Dictionary<string, Exercise>()
        };

        public List<string> GetSubjects()
        {
            var result = new List<string>();
            foreach (var str in Exercises.Keys)
            {
                result.Add(str);
            }
            return result;
        }

        public List<string> GetExerciseList(string subjectName)
        {
            var result = new List<string>();
            foreach(var str in Exercises[subjectName].Keys)
            {
                result.Add(str);
            }
            return result;
        }

        public Exercise GetExercise(string subjectName, string taskName)
        {
            return Exercises[subjectName][taskName];
        }
    }

    public struct Exercise
    {
        public string Name;
        public string Text;
        public string TextComment;
        public string[] Hints;
        public int usedHints;

        public Exercise(string n, string t, string tc, string[] l)
        {
            Name = n;
            Text = t;
            TextComment = tc;
            Hints = l;
            usedHints = 0;
        }
    }
}
