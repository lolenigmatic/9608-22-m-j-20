Imports System

Module Program

    'Custom made .split() method for reading from text file
    Function splitString(stringToSplit As String, delimiter As String)

        Dim splitArray(2) As String
        Dim arrayIndex As Integer = 0

        For Each c As Char In stringToSplit

            If c = delimiter Then
                arrayIndex += 1
            Else
                splitArray(arrayIndex) += c
            End If

        Next

        Return splitArray
    End Function

    'The text file will be in the format "TITLE#AUTHOR#ISBN"

    Sub Main(args As String())

        'init
        Dim userInput As String
        Dim newBookName As String
        Dim newBookAuthor As String
        Dim newBookISBN As String
        Dim finalString As String
        Dim currentLine As String
        Dim currentLineArr() As String
        Dim authorsFoundArr(0) As String
        Dim arrIndex = 1
        Dim searchTerm As String

        'prompt
        Console.WriteLine("1. Add new book")
        Console.WriteLine("2. Search Author's books")

        'user input
        userInput = Console.ReadLine

        Select Case userInput
            Case 1

                Dim fileWrite As IO.StreamWriter = New IO.StreamWriter("LibraryData.txt", True)
                Console.WriteLine("What is the book name?")
                newBookName = Console.ReadLine
                Console.WriteLine("What is the author's name?")
                newBookAuthor = Console.ReadLine
                Console.WriteLine("What is the book's ISBN?")
                newBookISBN = Console.ReadLine

                'Concat final string to be written to file
                finalString = newBookName & "#" & newBookAuthor & "#" & newBookISBN
                fileWrite.WriteLine(finalString)
                fileWrite.Close()
            Case 2
                'User search input

                Dim fileRead As IO.StreamReader = New IO.StreamReader("LibraryData.txt")
                Console.WriteLine("What author would you like to search for?")
                searchTerm = Console.ReadLine

                'Reading file until end
                Do Until fileRead.EndOfStream

                    currentLine = fileRead.ReadLine()
                    currentLineArr = splitString(currentLine, "#")

                    If currentLineArr(1) = searchTerm Then 'arr index 1 is the author, therefore must equal searchTerm

                        'super clunky and bad array logic, fixed soon
                        Array.Resize(authorsFoundArr, arrIndex)
                        authorsFoundArr(arrIndex - 1) = currentLineArr(0)
                        arrIndex += 1

                    End If
                Loop

                'Outputting results
                For i = 0 To authorsFoundArr.Length - 1
                    Console.WriteLine(authorsFoundArr(i))
                Next

                fileRead.Close()

            Case Else

        End Select

        Console.ReadLine()

    End Sub
End Module

