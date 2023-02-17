#!/bin/bash

echo Restoring backend dependencies
dotnet restore RINovus.sln

#pending add packages installation for front-end app
#echo Restoring frontend dependencies
#cd xyz
#npm i

echo Done!
