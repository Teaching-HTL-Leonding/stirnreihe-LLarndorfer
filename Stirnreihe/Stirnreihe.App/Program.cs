using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using Stirnreihe.Data;
string firstname;
string lastname;
int height;

Console.WriteLine("Welcome to the Stirnreihe World Record App! What do you want to do? \n1) Add a person to the line \n1b) Add a person to the line (sorted) \n2) Print the line \n3) Clear the line \n4) Exit");
var lineofpeople = new LineOfPeople(null);
while (true)
{
    Console.Write("Your choice: ");
    string userinput = Console.ReadLine()!;

    switch (userinput)
    {
        case "1":

            Console.Write($"First name: ");
            firstname = Console.ReadLine()!;
            Console.Write($"Last Name: ");
            lastname = Console.ReadLine()!;
            Console.Write($"Height in cm: ");
            height = int.Parse(Console.ReadLine()!);
            Person? person = new Person(firstname, lastname, height);
            lineofpeople.AddToFront(person);
            break;

        case "1b":
            Console.Write($"First name: ");
            firstname = Console.ReadLine()!;
            Console.Write($"Last Name: ");
            lastname = Console.ReadLine()!;
            Console.Write($"Height in cm: ");
            height = int.Parse(Console.ReadLine()!);
            Person? sortedperson = new Person(firstname, lastname, height);
            int index = lineofpeople.AddSorted(sortedperson);
            System.Console.WriteLine($"{sortedperson.FirstName} lined up at index {index}");
            break;

        case "2":
            for (var current = lineofpeople.First; current != null; current = current.next)
            {
                Console.WriteLine(current.person);
            }

            break;

        case "3":
            lineofpeople.Clear();
            break;


        case "4":
            throw new ArgumentException("Exit pressed");
    }
}