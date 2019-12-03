1. Run Asp.net Core (Server)
  Run command:  cd store_AspCore/store
                dotnet watch run
 
2. Run Angular (Client)
  Download & Install https://nodejs.org/dist/v12.13.1/node-v12.13.1-x64.msi
  Run command: npm install -g @angular/cli
  
  2.1) Run store
    Run command:  npm install
                  cd store
                  ng serve
                  
  2.2) Run admin
    Run command:  npm install
                  cd admin
                  ng serve --port 4001
