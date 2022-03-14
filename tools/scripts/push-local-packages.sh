#!/bin/bash

if [ ! -d ./packages ]; then
  mkdir -p ./packages;
fi

echo "Pushing all local nuget packages..."

readarray -d '' items < <(find -name "*.nupkg" -not -path "./packages/*" -print0)
itemCount=${#items[*]}

echo "${itemCount} package(s) found."

i=0

while [ $i -lt $itemCount ]
do
dotnet nuget push ${items[$i]} -s Local
let i++
done