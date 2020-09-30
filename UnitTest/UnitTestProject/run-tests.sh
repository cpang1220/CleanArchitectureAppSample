#!/bin/bash
set -eu -o pipefail

dotnet restore UnitTestProject.csproj
dotnet test UnitTestProject.csproj