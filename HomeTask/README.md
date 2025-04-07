# Support Ticket Analyzer

This project is a command-line tool designed to read support tickets from JSON, 
categorize them based on common keywords, 
and generate a summary report. 
It also allows users to filter tickets based on their age relative to a specified date.

## Features

- Read support tickets from JSON files.
- Categorize tickets based on predefined keywords.
- Generate a summary report with counts per category.
- List tickets that are older than a user-specified date.

## Build

To build the solution, run:

```
cd <solution_path>
dotnet build
```

## Usage

To run the tool, execute the following command in your terminal:

```
cd <dll_path>
dotnet .\HomeTask.dll <file_path> <date>
```

- `<file_path>`: The path to the JSON or CSV file containing the support tickets.
- `<date>`: The cutoff date in the format dd-MM-yyyy. Tickets older than this date will be included in the report.

## Example

```
dotnet .\bin\Debug\net8.0\HomeTask.dll tickets.json 24-12-2023
```

This command will read the `tickets.json` file and generate a report for tickets older than December 24, 2023.

## License

This project is licensed under the MIT License.