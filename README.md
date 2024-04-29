# Overview
This API provides a facade for searching GitHub repositories base on user-provided search query. 
The API offers swagger based documentation as well in `https://example.com/swagger` where `example.com` is the base url of the deployed endpoint.

## GET /api/GitHub/search/all/{query}

This endpoint will search all public repositories provided a search criteria (query). 

### Javascript Example

1. Replace `'https://example.com'` in the code with the actual base URL of your API endpoint.
2. Call the `searchGitHub` function with a query parameter to make a GET request to the API.

```javascript
const BASE_URL = 'https://example.com';

function searchGitHub(query) {
  const url = `${BASE_URL}/api/GitHub/search/all/${query}`;
  
  fetch(url)
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log(data);
    })
    .catch(error => {
      console.error('There was a problem with the fetch operation:', error);
    });
}

searchGitHub('javascript');

```

*Return Data*
```
{
    "isSuccessful": true,
    "errorMessage": null,
    "data": [
        {
            "repositoryName": "a",
            "ownerLogin": "ncek-XD",
            "repositoryUrl": "https://github.com/ncek-XD/a"
        },
        {
            "repositoryName": "A-Bot",
            "ownerLogin": "botengine-de",
            "repositoryUrl": "https://github.com/botengine-de/A-Bot"
        }
    ]
}
```


## GET /api/GitHub/search/{username}/{token}/{query}

Retrieves all repositories that belong to a user that match a search criteria. 
The `token` paramter is a GitHub personal access token which can be generated at https://github.com/settings/tokens .

### Javascript Example

1. Replace `'https://example.com'` in the code with the actual base URL of your API endpoint.
2. Call the `searchGitHub` function with all three parameters (`username`, `token`, and `query`) to make a GET request to the API.

```javascript
const BASE_URL = 'https://example.com';

function searchGitHub(username, token, query) {
  const url = `${BASE_URL}/api/GitHub/search/{username}/{token}/{query}`;
  
  fetch(url)
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log(data);
    })
    .catch(error => {
      console.error('There was a problem with the fetch operation:', error);
    });
}

searchGitHub('joe', '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', 'javascript');

```

*Return Data*
```
{
    "isSuccessful": true,
    "errorMessage": null,
    "data": [
        {
            "repositoryName": "HttpBuildQuery",
            "ownerLogin": "joe",
            "repositoryUrl": "https://github.com/joe/HttpBuildQuery"
        },
        {
            "repositoryName": "ShowTracker",
            "ownerLogin": "joe",
            "repositoryUrl": "https://github.com/joe/ShowTracker"
        }
    ]
}

```


## GitHub Tokens

To get a API token from Github generate a token at https://github.com/settings/tokens .