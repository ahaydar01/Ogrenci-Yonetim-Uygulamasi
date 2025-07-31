## Student Management Console App (C#)

>Note: This application is written in Turkish for educational purposes. All user interface messages and variable names are in Turkish.

## Description

This is a simple console-based Student Management System developed in C#.
The application allows the user to:

- Add a new student
- Delete a student by number
- List all students
- Exit the program

## Features

- Menu-driven interaction with input validation
- Supports up to 10 attempts for valid menu selection
- Prevents duplicate student numbers
- Proper formatting using PadLeft and PadRight for clean table display
- Names and surnames are automatically formatted (first letter capitalized)

## Project Structure

- `Program.cs`: Main program logic
- `Ogrenci` class: Defines the student model with `Ad`, `Soyad`, `OgrenciNo`, and `Sube`

## Sample Menu

1- Öğrenci Ekle (E)
2- Öğrenci Sil (S)
3- Öğrenci Listele (L)
4- Çıkış (X)
## Technologies

- C# (.NET Console Application)
- .NET SDK 6.0 or above (recommended)

## How to Run

1. Open the project in Visual Studio or any C# IDE
2. Build and run `Program.cs`
3. Follow the instructions in the console

## To-Do (Optional Improvements)

- Save data to file or database
- Support editing student info
- English version of the UI
- Add birthdate or contact info fields

---

Created for educational purposes.

