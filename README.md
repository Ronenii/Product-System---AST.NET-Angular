# Running the Project Locally 

## 1. Start the MySQL Database 
In the repository, the `docker-compose.yml` file is located in the `backend` directory. Follow these steps to start the MySQL database: 
- Open a terminal and navigate to the `backend` directory.
 
- Run the following command to start the MySQL database:

```Copy code
docker-compose up
```
This will pull and start the MySQL container defined in the `docker-compose.yml` file.
## 2. Run the Backend (ASP.NET Core Web API) 
 
- Open the backend project in your IDE (JetBrains Rider or any other).
 
- Ensure that all dependencies are installed.
 
- By default, the backend is configured to run on `http://localhost:5145`. To make sure it works as expected:
  - Check the HTTP profile settings in your IDE (JetBrains Rider in this case).
 
  - Ensure the launch settings for the backend API are set to use port `5145`.
If you want to manually configure the port, update the launch settings in `launchSettings.json`:

```Copy code
"profiles": {
  "http": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "applicationUrl": "http://localhost:5145",
    "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
    }
  }
}
```
 
- Run the backend using the following command:


```Copy code
dotnet run
```
 
- The backend should now be running and accessible at `http://localhost:5145`.

## 3. Run the Frontend (Angular) 

- Navigate to the frontend project directory.
 
- Install the required dependencies:

```Copy code
npm install
```
 
- The frontend is already set up to send requests to `http://localhost:5145` (the backend API).
 
- Run the frontend using the following command:

```Copy code
ng serve
```
 
- The frontend will be accessible at `http://localhost:4200`.

## 4. User Registration 

Users can register via the frontend and select whether they are admins or regular users during the registration process.
