This web application has four end points:
API:			/api/MyTask/PostData
Input parameter:		MyRequest (json object);
Return parameter:	string (status of http request 
Transfer Type:		HttpPost
Description:		Sends request to the client

API:			/api/MyTask/RequestReceived
Input parameter:		requestId (string), requestStatus (string)
Return parameter:	204 
Transfer Type:		HttpPost
Description:		Client sends initial status that work started

API:			/api/MyTask/UpdateRequestStatus
Input parameter:		requestId (string), ClientAPIResponse (json)
Return parameter:	204 
Transfer Type:		HttpPut
Description:		Client sends status update

API:			/api/MyTask/CheckStatus
Input parameter:		requestId (string);
Return parameter:	ClientResponse (json) 
Transfer Type:		HttpGet
Description:		Sends request to the client

This application is set to use IIS Express
This application uses InMemory database
Use Postman to test API calls
