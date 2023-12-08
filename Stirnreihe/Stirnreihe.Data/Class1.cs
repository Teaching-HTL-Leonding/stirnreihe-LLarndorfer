using System.Globalization;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Stirnreihe.Data;

public class Person(string firstName, string lastName, int height)
{
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public int? Height { get; set; } = height;

    public override string ToString()
    {
        return $"{LastName}, {FirstName} ({Height} cm)";
    }
}


public class Node(Person person, Node? next)
{
    public Person person { get; set; } = person;
    public Node? next { get; set; } = next;
}

public class LineOfPeople(Node? First)
{
    public Node? First { get; set; } = First;
    public void AddToFront(Person person)
    {

        var node = new Node(person, First);
        // if(First != null)
        // {
        // First.next = First;
        // }
        First = node;


    }

    public int AddSorted(Person person)
    {
        

        var counter = 1;
        if (First == null || person.Height < First.person.Height)
        {
            AddToFront(person);
            return 0;
        }

        Node current = First; // Außerhalb die Deklaration

        for (; current.next != null; current = current.next)
        {

            if (person.Height < current.next.person.Height) // Durch <, statt <= geht er bei gleichen Größen durch bis entweder jemand größeres current.next ist, oder bis current.next null ist. Dadurch reiht sich eine gleiche Person, mit der gleichen Höhe hinten ein.
            {
                break;
            }
            counter++;
        }


        var sortednode = new Node(person, current.next);
        current.next = sortednode;
        return counter;    
        // current = sortednode;
    }


    public void Clear()
    {
        First = null;
    }
}