
# URL Shortening Service 🚀

A simple and efficient URL shortening service built with **ASP.NET Core**. This service allows users to shorten long URLs, retrieve the original URLs, update existing URLs, delete shortened URLs, and view usage statistics.

---

## **Features**
- **Shorten Long URLs**: Generate a unique and concise short code for any valid URL.
- **Retrieve Original URL**: Redirect to the original URL using the short code.
- **Update Shortened URL**: Modify the original URL for an existing short code.
- **Delete Shortened URL**: Remove a short code and its associated URL.
- **Track Statistics**: View how many times a short URL has been accessed.

---

## **Project Idea**
This project is based on the [roadmap.sh URL Shortening Service](https://roadmap.sh/projects/url-shortening-service) idea, which is a beginner-friendly project to learn backend development. Key learning goals include:
- **RESTful API Design**: Implementing CRUD operations for a web service.
- **Database Integration**: Storing URLs and tracking access counts.
- **Validation and Error Handling**: Ensuring input data integrity and handling errors gracefully.
- **URL Redirection**: Enabling HTTP redirection from short URLs to original URLs.

---

## **Endpoints**

### 1. **Create Short URL**
   **POST** `/api/shorturls`
   ```json
   {
       "url": "https://www.example.com/very/long/url"
   }
   ```
   **Response**: `201 Created`
   ```json
   {
       "id": 1,
       "originalUrl": "https://www.example.com/very/long/url",
       "shortCode": "abc123",
       "createdAt": "2024-11-01T12:00:00Z",
       "updatedAt": "2024-11-01T12:00:00Z"
   }
   ```

### 2. **Retrieve Original URL**
   **GET** `/api/shorturls/{shortCode}`
   **Response**: `200 OK`
   ```json
   {
       "id": 1,
       "originalUrl": "https://www.example.com/very/long/url",
       "shortCode": "abc123",
       "createdAt": "2024-11-01T12:00:00Z",
       "updatedAt": "2024-11-01T12:00:00Z"
   }
   ```

### 3. **Update Shortened URL**
   **PUT** `/api/shorturls/{shortCode}`
   ```json
   {
       "url": "https://www.example.com/updated/url"
   }
   ```
   **Response**: `200 OK`
   ```json
   {
       "id": 1,
       "originalUrl": "https://www.example.com/updated/url",
       "shortCode": "abc123",
       "createdAt": "2024-11-01T12:00:00Z",
       "updatedAt": "2024-11-01T12:30:00Z"
   }
   ```

### 4. **Delete Shortened URL**
   **DELETE** `/api/shorturls/{shortCode}`
   **Response**: `204 No Content`

### 5. **Get URL Statistics**
   **GET** `/api/shorturls/{shortCode}/stats`
   **Response**: `200 OK`
   ```json
   {
       "id": 1,
       "originalUrl": "https://www.example.com/very/long/url",
       "shortCode": "abc123",
       "createdAt": "2024-11-01T12:00:00Z",
       "updatedAt": "2024-11-01T12:00:00Z",
       "accessCount": 10
   }
   ```

---

