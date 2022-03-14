#!/bin/bash
slnFile=booster-all

echo "Resetting $slnFile.sln file..."

rm -f "./$slnFile.sln"
dotnet new sln --name $slnFile

echo "Adding all projects to $slnFile.sln..."

readarray -d '' projects < <(find -name "*.csproj" -print0)
projectCount=${#projects[*]}

echo "${projectCount} project(s) found."

i=0

while [ $i -lt $projectCount ]
do
dotnet sln add ${projects[$i]}
let i++
done