# Introduction 
Mono repo for "Novus" software project.

# Getting Started
1.	Clone this repo
2.	Call `initial_setup` script to install all development dependencies. From root (`~`) run it like this `./scripts/initial_setup.sh`
3.	...

# Build and Test
## Run tests and see test coverage
```
dotnet test /p:CollectCoverage=true
```

# Contribute
## Project structure
```
.
├── README.md
├── RINovus.sln
├── scripts
│   └── initial_setup.sh
└── src
    ├── main
    │   ├── cs
    │   │   ├── boundaries
    │   │   ├── Core
    │   │   │   ├── Core.csproj
    │   │   │   ├── ...
    │   │   └── deployables
    │   ├── resources
    │   └── ts
    └── test
        ├── cs
        │   └── Core.Facts
        │       ├── Core.Facts.csproj
        │       ├── ...
        ├── resources
        └── ts
```
* `src`: All sources go here, for all programming languages.
* `main` and `test`: Contain production and test code, respectively.
* `deployables`: Contain project that can be deployed as independent processes, such as Web APIs, Background Services, Console Applications, etc. This only applies for backend technology.
* `boundaries`: Projects implementing infrastructure access.
* `Core`, `Core.Facts`, and future siblings: Class libraries and corresponding test code. 
* `resources`: Non-source code files required by production and test code.

wget -qO- https://aka.ms/install-artifacts-credprovider.sh | bash

dotnet restore --interactive
