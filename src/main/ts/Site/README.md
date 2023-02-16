# Introduction 

"Novus" Site An application used to support RI services built with React, typeScript, and SCSS.

# Getting Started
1.	Clone this repo
2.  From root (`~`) run `npm install`


# Installation and setup intructions
## To Run tests and see test coverage reports
```
npm test
```

### How to locate html coverage report
- From root on path: ~/src/main/ts/Site/output/code-coverage/lcov-report/index.html

### How to locate html test execution report 

- From root on path: ~/src/main/ts/Site/test-report.html

## To run code analysis
```
npm run lint
```

## To run project
```
npm run dev
```

# Contribute
## Project structure
```
.
├── README.md
├───output
│   └───code-coverage
│       └───lcov-report
└───src
    ├───higher-order-module
    │   ├───sub-module───├───components
    │                    ├───interfaces
    │                    ├───pages
    │                    ├───routers
    │                    └───tests
    │   
    ├───core
    │   └───components
    ├───shared
    │   ├───components
    │   ├───hooks
    │   ├───interfaces
    │   └───tests
    └───tests
        └───__snapshots__
```
* `output`: Contains the test coverage report.
* `src`: All sources go here, for the React site.
* `higher-order-module`: This will represent a higher order module like backoffice, cadastral-survey, titles registration, etc. higher-order-module name is for explain more easily the project structure.
* `sub-module`: Will contains sub modules of the higher order module like users, requests, and other modules. This will contain components, interfaces, pages, routers, tests used on this module. 
* `core`: Contains layout elements, auth related stuffs like pages, auth guards, etc.
* `shared`: Contains general reusable elements like React functional components, hooks, interfaces and its corresponding tests.
* `main` and `test`: Contain production and test code, respectively.

# Vs code extensions that needs to be installed
1. Install ESLint

To set ESLint as default formatter
https://daveceddia.com/vscode-use-eslintrc/#:~:text=Configure%20VSCode%20Settings%20to%20use%20ESLint%20for%20Formatting&text=Click%20that%20tiny%20icon%20in,paper%20with%20a%20little%20arrow.&text=The%20first%20one%20turns%20on,it%2C%20we're%20done.


