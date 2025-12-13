using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FinalProject
{
    /// <summary>
    ///  Core class that uses CRUD operations to interface with a Dictionary and a Stack (For undoing delete operations)
    /// </summary>
    public class JuryManagement
    {
        // Stores active jurors
        Dictionary<int, Juror> jurors = new Dictionary<int, Juror>();
        
        // Summons the 12 earliest added jurors for a case
        Queue<Juror> jurorsToSummon = new Queue<Juror>();

        // Undo stack to reverse delete operations
        Stack<Juror> undoStack = new Stack<Juror>();

        // What the next JurorID will be
        int dictionaryIndex = 1;

        //How many undo operations have been conducted
        int undoCount = 0;

        public void populateJurorDictionary()
        {
            jurors = new Dictionary<int, Juror>
            {
                { 1, new Juror("John Smith", DateTime.Now) },
                { 2, new Juror("David Johnson", new DateTime(2026, 1, 1)) },
                { 3, new Juror("Sarah Ramirez", new DateTime(2025, 12, 30)) },
                { 4, new Juror("Holly Farley", new DateTime(2026, 1, 12)) },
                { 5, new Juror("Homer Thompson", new DateTime(2026, 1, 12)) },
                { 6, new Juror("Emily Wilson", new DateTime(2026, 1, 12)) },
                { 7, new Juror("Justin Case", new DateTime(2026, 1, 12)) },
                { 8, new Juror("Dewey Convict", new DateTime(2026, 1, 12)) },
                { 9, new Juror("Jennifer Innocent", new DateTime(2026, 1, 12)) },
                { 10, new Juror("Bob Gavel", new DateTime(2026, 1, 12)) },
                { 11, new Juror("Heather Judge", new DateTime(2026, 1, 12)) },
                { 12, new Juror("Miles Edgeworth", new DateTime(2026, 1, 12)) },
                { 13, new Juror("Will Judge", new DateTime(2026, 1, 12)) }
            };
            dictionaryIndex = 13;            
            //return jurorsNew;
        }

        public bool addJuror(Juror jurorToAdd)
        {
            try
            {
                while(jurors.ContainsKey(dictionaryIndex))
                {
                    dictionaryIndex++;
                }
                jurors.Add(dictionaryIndex, jurorToAdd);
                return true;
            }
            catch(InvalidDataException)
            {
                Console.WriteLine("Invalid juror");
                return false;
            }
        }
        public Juror? searchById(int i)
        {
            foreach(KeyValuePair<int, Juror> ele in jurors)
            {
                if(i == ele.Key)
                {
                    return ele.Value;
                }
            }
            return null;
        }
        public bool DeleteJuror(int i)
        {
            try
            {
                Juror? jurorToDelete = searchById(i);
                undoStack.Push(jurorToDelete);
                undoCount++;
                jurors.Remove(i);
                Console.WriteLine($"{jurorToDelete.FullName} removed from the roster");
                return true;
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("There are no jurors who match that ID.");
                return false;
            }
        }
        public bool UndoDelete()
        {
            if(undoCount > 0)
            {    
                dictionaryIndex++;
                jurors.Add(dictionaryIndex, undoStack.Pop());
                return true;
            }
            else
            {
                Console.WriteLine("Nothing to undo");
                return false;
            }
        }
        public bool UpdateJuror(int i, string newName)
        {
            try
            {
                Juror? jurorToUpdate = searchById(i);
                jurors[i].FullName = newName;
                return true;
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("No juror found at that ID");
                return false;
            }
        }
        public bool SummonJurors()
        {
            if(jurors.Count >= 12)
            {
                foreach(KeyValuePair<int, Juror> ele in jurors)
                {
                    jurorsToSummon.Enqueue(ele.Value);
                }
                for(int i = 0; i < 12; i++)
                {
                    Juror summonedJuror = jurorsToSummon.Dequeue();
                    Console.WriteLine($"Summoned {summonedJuror.FullName}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("Not enough jurors for a trial");
                return false;
            }
        }
        public void PrintDictionary()
        {
            foreach(KeyValuePair<int, Juror> ele in jurors)
            {
                Console.WriteLine($"Juror Name: {ele.Value.FullName}, Date of Service: {ele.Value.SummonsDate}, ID: {ele.Key}");
            }
        }
    }
}