#!/bin/bash

# Ensure the script is being run from the root folder of the solution
if [ ! -f "LingoPartner.sln" ]; then
  echo "Please run this script from the root folder of your solution where the .sln file is located."
  exit 1
fi

# Find all project files in the solution
project_files=$(find . -name "*.csproj")

# Check if any project files are found
if [ -z "$project_files" ]; then
  echo "No project files found in the solution."
  exit 1
fi

# Loop through each project file and list its dependencies and project references
for project_file in $project_files; do
  echo "Dependencies for project: $project_file"
  dotnet list "$project_file" package
  echo "Project references for project: $project_file"
  dotnet list "$project_file" reference
  echo "-----------------------------------------"
done
