# N5 CodeChallenge

## Starting the server

1. `docker-compose build`

2. `docker-compose up`


## Creating DB

1. `cd ./init`

2. `sqlcmd -S . -U sa -P secure_password.2022 -i ./create_database.sql`

3. `sqlcmd -S . -U sa -P secure_password.2022 -i ./init_database.sql`

    * DB tables will be created. "Permissions" and "PermissionTypes".
    * Table "PermissionTypes" will be seeded with some dummy types: 'Admin', 'Sales', 'Workshop', 'Finance'


## Make Requests

* ### RequestPermission:
    * endpoint: `http://localhost:44355/api/permission/request`
    * method: `POST`
    * body: 
        ```
        {
            "EmployeeForename": "Name",
            "EmployeeSurname": "Surname",
            "IdPermissionType": 1
        }
        ```

* ### ModifyPermission:
    * endpoint: `http://localhost:44352/api/permission/modify`
    * method: `PUT`
    * body:
        ``` 
        {
            "Id": 3,
            "EmployeeForename": "Modified Name",
            "EmployeeSurname": "Modified Surname",
            "IdPermissionType": 2
        }
        ```

* ### GetPermissions:
    * endpoint: `http://localhost:44352/api/permission/all`
    * method: `GET`


## ElasticSearch

`http://localhost:9200`

* When a request to 'RequestPermission' endpoint is triggered, am index and a document are genereated under `http://localhost:9200/permissions`

* To list all documents `http://localhost:9200/permissions/_search`

* You can add pretty query param to see a formatted JSON `http://localhost:9200/permissions/_search?pretty=true`


## View Logs

Logs will be visible on Docker Console